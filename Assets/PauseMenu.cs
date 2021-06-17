using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI , pCamera;

    

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }  
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        MouseStuff.MouseInvisible();
        MouseStuff.isCursorVisible = false;


    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        MouseStuff.MouseVisible();
        MouseStuff.isCursorVisible = true;


    }

    public void LoadMenu()
    {
        Debug.Log("CARREGANDO MENU...");
        SceneManager.LoadScene("MainMenu");
       
    }


    public void LoadCapitulo()
    {

        Debug.Log("CARREGANDO CAPITULO...");
        SceneManager.LoadScene("Capitulos");

    }

}
