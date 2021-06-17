using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLivro : MonoBehaviour
{
    public GameObject HUD_NPCQuestLivro;

     void Start()
    {
        HUD_NPCQuestLivro.SetActive(false);
    }

     void OnTriggerEnter(Collider hit){
        if(hit.gameObject.tag == "Player_3.0") {
            HUD_NPCQuestLivro.SetActive(true);
        }
    }


    void OnTriggerExit(Collider hit){

        if (hit.gameObject.tag == "Player_3.0"){
            HUD_NPCQuestLivro.SetActive(false);

        }
    }


}
    



