using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor_Ativa_outro : MonoBehaviour
{
    public Transform jogador1;
    public AudioClip somBotao1;
    public KeyCode teclaAcenderLigar = KeyCode.E;


    [Range(7, 10)]
    public float distanciaMinima1 = 7;
    public bool AlavancaAtiva = false;
    [Space(15)]
    public GameObject objInterruptorOn1;
    public GameObject objInterruptorOff1;

    [Space(15)]
    public Light luz1;
    public GameObject ObjLigado;
    public GameObject objDesligado;

    //
    float distancia;
    AudioSource aud;


    void Awake()
    {
        aud = GetComponent<AudioSource>();



        if (somBotao1)
        {
            aud.clip = somBotao1;
        }



        aud.playOnAwake = false;
        aud.loop = false;


        //
        if (ObjLigado)
        {
            ObjLigado.SetActive(AlavancaAtiva);
        }


        if (objDesligado)
        {
            objDesligado.SetActive(!AlavancaAtiva);
        }


        if (luz1)
        {
            luz1.enabled = AlavancaAtiva;
        }


        if (objInterruptorOn1)
        {
            objInterruptorOn1.SetActive(AlavancaAtiva);
        }

        if (objInterruptorOff1)
        {
            objInterruptorOff1.SetActive(!AlavancaAtiva);
        }
        //


    }

    // Update is called once per frame
    void Update()
    {
        if (jogador1)
        {
            distancia = Vector3.Distance(transform.position, jogador1.transform.position);

            if (distancia < distanciaMinima1)
            {
                if (Input.GetKeyDown(teclaAcenderLigar))
                {
                    AlavancaAtiva = !AlavancaAtiva;

                    if (aud.clip != null)
                    {
                        aud.PlayOneShot(aud.clip);
                    }
                    //

                    if (ObjLigado)
                    {
                        ObjLigado.SetActive(AlavancaAtiva);
                    }


                    if (objDesligado)
                    {
                        objDesligado.SetActive(!AlavancaAtiva);
                    }


                    if (luz1)
                    {
                        luz1.enabled = AlavancaAtiva;
                    }


                    if (objInterruptorOn1)
                    {
                        objInterruptorOn1.SetActive(AlavancaAtiva);
                    }

                    if (objInterruptorOff1)
                    {
                        objInterruptorOff1.SetActive(!AlavancaAtiva);
                    }

                }
            }
        }
    }


}
