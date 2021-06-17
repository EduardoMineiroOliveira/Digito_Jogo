using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inimigo_Ataque : MonoBehaviour
{
    public Slider vidaPlayer;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            vidaPlayer.value--;
        }
    }

    private void Update()
    {
        if (vidaPlayer.value == 0)
        {

            SceneManager.LoadScene("GameOver");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 12);
            //player.SetActive(false);
        }
    }


}
