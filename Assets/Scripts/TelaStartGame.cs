using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaStartGame : MonoBehaviour
{

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            Debug.Log("CARREGANDO TelaFinal...");
            SceneManager.LoadScene("Loading_StartGame");
        }


    }

}

