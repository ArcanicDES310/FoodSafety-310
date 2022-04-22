using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{



    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject miniClipboard;


    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
           


            if(GameIsPaused)
            {
                
                Resume();
            }
            else
            {
                miniClipboard.SetActive(false);
                Pause();
            }
        }
   
    }

    public void Resume()
    {

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        miniClipboard.SetActive(true);
        GameIsPaused = false;

    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Exit Done");
        Application.Quit();
    }

    public void leftArrowClick()
    {
        Debug.Log("left arrow pressed");
    }
}
