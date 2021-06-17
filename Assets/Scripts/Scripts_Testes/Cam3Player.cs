using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam3Player : MonoBehaviour
{
    public GameObject cabeca;
    public GameObject[] posicoes;
    public int indice = 0;
    public float VelocidadeDeMovimento = 2;
    private RaycastHit hit;

    void FixedUpdate()
    {
        transform.LookAt(cabeca.transform);
        //checar se tem colisor
        if (!Physics.Linecast(cabeca.transform.position, posicoes[indice].transform.position))
        {
            transform.position = Vector3.Lerp(transform.position, posicoes[indice].transform.position, VelocidadeDeMovimento*Time.deltaTime);
            Debug.DrawLine(cabeca.transform.position, posicoes[indice].transform.position);
        }

        else if(Physics.Linecast(cabeca.transform.position, posicoes[indice].transform.position,out hit)){ //controlador de velocidade
            transform.position = Vector3.Lerp(transform.position, hit.point, (VelocidadeDeMovimento*2)*Time.deltaTime);
            Debug.DrawLine(cabeca.transform.position, hit.point);

        }

    }

    void Update() //função para mudar a posições de camera via teclado
    {
        if(Input.GetKeyDown("j") && indice < (posicoes.Length - 1)){
            indice++;
        }
        else if (Input.GetKeyDown("j") && indice >= (posicoes.Length - 1))
        {
            indice = 0;
        }
    }

}
