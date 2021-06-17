using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mensagem : MonoBehaviour
{ //o seu jogador deve a tag "Player"


    public Text texto;
    public Image customImage;
    public Image photo_profile;


    [Range(0.1f, 10.0f)] public float distancia = 3;


    private GameObject Jogador;
    

    void Start()
    {
        texto.enabled = false;
        customImage.enabled = false;
        photo_profile.enabled = false;
        Jogador = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, Jogador.transform.position) < distancia)
        {
            texto.enabled = true;
            customImage.enabled = true;
            photo_profile.enabled = true;
        }
        else
        {
            texto.enabled = false;
            customImage.enabled = false;
            photo_profile.enabled = false;
        }
    }
}
