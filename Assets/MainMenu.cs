using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("Loading_StartGame");
    }


    public void Capitulos()
    {
        SceneManager.LoadScene("Capitulos");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void MenuPrincipal()
    {

        Debug.Log("CARREGANDO MENU...");
        SceneManager.LoadScene("MainMenu");
        
    }



    //work artes digito
    public void Intro()
    {

        Debug.Log("CARREGANDO INTRO...");
        SceneManager.LoadScene("Intro");

    }


    //cena para ajudar o Javus
    public void PularIntro()
    {

        Debug.Log("CARREGANDO CUTSCENE INTRO...");
        SceneManager.LoadScene("Loading_CutSceneIntro");

    }



  

    // Cena para os capitulos tela


    public void Cena2()
    {

        Debug.Log("CARREGANDO cena2...");
        SceneManager.LoadScene("Loading_Cena2");

    }

    public void Cena3()
    {

        Debug.Log("CARREGANDO cena3...");
        SceneManager.LoadScene("Loading_Cena3");

    }




    public void Cena4()
    {

        Debug.Log("CARREGANDO cena4...");
        SceneManager.LoadScene("Loading_Cena4");

    }


    public void Cena5()
    {

        Debug.Log("CARREGANDO cena5...");
        SceneManager.LoadScene("Loading_Cena5");

    }


    public void Cena6()
    {

        Debug.Log("CARREGANDO cena6...");
        SceneManager.LoadScene("Loading_Cena6");

    }



    //quit

    public void QuitGame ()
    {
        Debug.Log("SIM EU SAI");
        Application.Quit();
    }



}
