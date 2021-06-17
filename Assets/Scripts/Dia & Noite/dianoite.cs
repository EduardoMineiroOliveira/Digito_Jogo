using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class ClasseNuvens
{
	[Range(1, 50)]
	public float Velocidade = 5;
	[Range(2, 50)]
	public float Altura = 17.0f;
	[Range(0.1f, 1)]
	public float Quantidade = 0.2f;
	[Range(0, 10)]
	public float Claridade = 9.0f;
	[Range(0.4f, 5.0f)]
	public float TamanhoDaNuvem = 1.4f;
	[Range(0, 50)]
	public float Intensidade = 30;
	[Range(10, 100)]
	public float OpacidadeHorizonte = 50;
	public Shader ShaderDoObjeto;
	public Texture TexturaShader;
	[HideInInspector]
	public GameObject bola;
	[Range(500, 5000)]
	public int escalaDaEsfera = 2000;
}

[Serializable]
public class ConfigsDia
{
	public float DuracaoDiaMin = 60;
	[Range(0, 8)]
	public float IntensidadeLuzDia = 1;
	[Range(0, 8)]
	public float IntensidadeLuzAmbienteDia = 1;
	[Range(0.1f, 100)]
	public float VelocidadeInteracao = 1;
	[Range(0.2f, 1)]
	public float HoraLuzesNoite = 0.4f;
	[Range(0, 8)]
	public float ReflexosLuzDia = 1;
}

public class dianoite : MonoBehaviour
{

	public ClasseNuvens Nuvens;
	public ConfigsDia ConfigsDoDia;
	public Light[] LuzesNoite;
	public GameObject Jogador;
	private Light componenteLuz;
	private bool ativou1x;
	private float intensidadeCor;

	void Awake()
	{
		Nuvens.bola = new GameObject("EsferaNuvens");
		Nuvens.bola.AddComponent(typeof(MeshFilter));
		Nuvens.bola.AddComponent(typeof(MeshRenderer));
		GameObject bolaTemp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		Nuvens.bola.GetComponent<MeshFilter>().mesh = bolaTemp.GetComponent<MeshFilter>().mesh;
		Destroy(bolaTemp);
		Nuvens.bola.transform.localScale = new Vector3(20 * Nuvens.escalaDaEsfera, Nuvens.escalaDaEsfera, 20 * Nuvens.escalaDaEsfera);
		Nuvens.bola.GetComponent<Renderer>().material.shader = Nuvens.ShaderDoObjeto;
		Nuvens.bola.GetComponent<Renderer>().material.mainTexture = Nuvens.TexturaShader;
	}

	void Start()
	{
		
		AtivarLuzes(false);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
		componenteLuz = GetComponent<Light>();
		componenteLuz.renderMode = LightRenderMode.ForcePixel;
		RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
		RenderSettings.ambientSkyColor = componenteLuz.color;
		intensidadeCor = Mathf.Clamp((transform.eulerAngles.x / 90), 0, 1);
	}

	void Update()
	{
		if (Jogador != null)
		{
			Nuvens.bola.transform.position = Jogador.transform.position;
		}
		SetarShaderUpdate();
		if (ConfigsDoDia.DuracaoDiaMin > 0)
		{
			transform.Rotate((6.0f / ConfigsDoDia.DuracaoDiaMin) * Time.deltaTime, 0, 0);
		}
		if (transform.eulerAngles.x > 0 && transform.eulerAngles.x < 180)
		{
			intensidadeCor = Mathf.Lerp(intensidadeCor, Mathf.Abs(transform.eulerAngles.x / 90), Time.deltaTime * ConfigsDoDia.VelocidadeInteracao);
			
			RenderSettings.ambientIntensity = Mathf.Lerp(RenderSettings.ambientIntensity, (0.15f + ConfigsDoDia.IntensidadeLuzAmbienteDia * Mathf.Abs(transform.eulerAngles.x / 90)), Time.deltaTime * ConfigsDoDia.VelocidadeInteracao);
			RenderSettings.reflectionIntensity = Mathf.Lerp(RenderSettings.reflectionIntensity, (0.1f + ConfigsDoDia.ReflexosLuzDia * Mathf.Abs(transform.eulerAngles.x / 90)), Time.deltaTime * ConfigsDoDia.VelocidadeInteracao);
			componenteLuz.intensity = Mathf.Lerp(componenteLuz.intensity, (ConfigsDoDia.IntensidadeLuzDia / 2 + ConfigsDoDia.IntensidadeLuzDia * Mathf.Abs(transform.eulerAngles.x / 360)), Time.deltaTime * ConfigsDoDia.VelocidadeInteracao);
		}
		else
		{
			intensidadeCor = Mathf.Lerp(intensidadeCor, 0.0f, Time.deltaTime * ConfigsDoDia.VelocidadeInteracao * 0.4f);
			RenderSettings.ambientSkyColor = componenteLuz.color * Mathf.Clamp(intensidadeCor, 0.0f, 1.0f);
			RenderSettings.ambientIntensity = Mathf.Lerp(RenderSettings.ambientIntensity, 0.0f, Time.deltaTime * ConfigsDoDia.VelocidadeInteracao);
			RenderSettings.reflectionIntensity = Mathf.Lerp(RenderSettings.reflectionIntensity, 0.0f, Time.deltaTime * ConfigsDoDia.VelocidadeInteracao);
			componenteLuz.intensity = Mathf.Lerp(componenteLuz.intensity, 0.01f, Time.deltaTime * ConfigsDoDia.VelocidadeInteracao);
		}
		if (RenderSettings.ambientIntensity < ConfigsDoDia.HoraLuzesNoite && ativou1x == false)
		{
			AtivarLuzes(true);
			ativou1x = true;
		}
		else if (RenderSettings.ambientIntensity >= ConfigsDoDia.HoraLuzesNoite)
		{
			AtivarLuzes(false);
			ativou1x = false;
		}
	}

	void AtivarLuzes(bool condic)
	{
		for (int x = 0; x < LuzesNoite.Length; x++)
		{
			LuzesNoite[x].enabled = condic;
		}
	}

	void SetarShaderUpdate()
	{
		Shader.SetGlobalFloat("_velocidade", Time.time * Nuvens.Velocidade);
		Shader.SetGlobalFloat("_altura", Nuvens.Altura);
		Shader.SetGlobalFloat("_quantidade", Nuvens.Quantidade);
		Shader.SetGlobalFloat("_claridade", Nuvens.Claridade);
		Shader.SetGlobalFloat("_tamanhoNuvem", (1 / Nuvens.TamanhoDaNuvem));
		Shader.SetGlobalFloat("_intensidade", Nuvens.Intensidade);
		Shader.SetGlobalFloat("_opacidadeHorizonte", Nuvens.OpacidadeHorizonte);
	}
}
