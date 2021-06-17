using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Interruptor : MonoBehaviour
{
    public Transform jogador;
    public AudioClip somBotao;
    public KeyCode teclaAcenderLuz = KeyCode.E;


    [Range(7,10)]
    public float distanciaMinima = 7;
    public bool luzLigada = false;
    [Space(15)]
    public GameObject objInterruptorOn;
    public GameObject objInterruptorOff;

    [Space(15)]
    public Light luz;
    public GameObject ObjLuzAcessa;
    public GameObject objLuzApagada;

    //
    float distancia;
    AudioSource aud;


    void Awake()
    {
        aud = GetComponent<AudioSource>();



        if (somBotao)
        {
            aud.clip = somBotao;
        }



        aud.playOnAwake = false;
        aud.loop = false;


        //
        if (ObjLuzAcessa)
        { 
        ObjLuzAcessa.SetActive(luzLigada);
        }


        if (objLuzApagada)
        {
            objLuzApagada.SetActive(!luzLigada);
        }


        if (luz)
        {
            luz.enabled = luzLigada;
        }


        if (objInterruptorOn)
        {
            objInterruptorOn.SetActive(luzLigada);
        }

        if (objInterruptorOff)
        {
            objInterruptorOff.SetActive(!luzLigada);
        }
        //

    
    }

    // Update is called once per frame
    void Update()
    {
        if (jogador)
        {
            distancia = Vector3.Distance(transform.position, jogador.transform.position);

            if(distancia < distanciaMinima)
            {
                if (Input.GetKeyDown(teclaAcenderLuz))
                {
                    luzLigada = !luzLigada;

                    if (aud.clip != null)
                    {
                        aud.PlayOneShot(aud.clip);
                    }
                    //

                    if (ObjLuzAcessa)
                    {
                        ObjLuzAcessa.SetActive(luzLigada);
                    }


                    if (objLuzApagada)
                    {
                        objLuzApagada.SetActive(!luzLigada);
                    }


                    if (luz)
                    {
                        luz.enabled = luzLigada;
                    }


                    if (objInterruptorOn)
                    {
                        objInterruptorOn.SetActive(luzLigada);
                    }

                    if (objInterruptorOff)
                    {
                        objInterruptorOff.SetActive(!luzLigada);
                    }

                }
            }
        }
    }
    
        
}

