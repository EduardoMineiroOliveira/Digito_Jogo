using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Livro_Script : MonoBehaviour
{
    public Text textos;
    public Image customImages;
    public Text textos2;
    public Image photo_profiles;


    [Range(0.1f, 10.0f)] public float distancias = 3;


    private GameObject Jogadores;


    void Start()
    {
        textos.enabled = false;
        customImages.enabled = false;
        textos2.enabled = false;
        photo_profiles.enabled = false;
        Jogadores = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Jogadores.transform.position) < distancias)
        {
            textos.enabled = true;
            customImages.enabled = true;
            textos2.enabled = true;
            photo_profiles.enabled = true;
        }
        else
        {
            textos.enabled = false;
            customImages.enabled = false;
            textos2.enabled = false;
            photo_profiles.enabled = false;
        }
    }
}
