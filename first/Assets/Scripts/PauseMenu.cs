using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject character;
    movement2 moveScript;

    public static bool GameIsPaused = false;


    //UIPanels
    public GameObject pauseMenuUI;
    public GameObject tutorialMenuUI;
    public GameObject objectivesMenuUI;
    public GameObject controlsMenuUI;


   // public GameObject menuFunctionality;
    public GameObject miniClipboard;
    public GameObject NpcPanel;
    public GameObject BWInteractButton;
    public GameObject MinimapPanel;

    //GIFs
    public GameObject lockerGif;

    private void Start()
    {
        moveScript = character.GetComponent<movement2>();

    }
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

       // menuFunctionality.SetActive(false);
       // Time.timeScale = 1f;
        miniClipboard.SetActive(true);
        GameIsPaused = false;
        BWInteractButton.SetActive(true);
        moveScript.enabled = true;
        MinimapPanel.SetActive(true);


        //UI
        pauseMenuUI.SetActive(false);
        tutorialMenuUI.SetActive(false);
        objectivesMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);

        //GIFs
        lockerGif.SetActive(false);
        

    }

    public void Pause()
    {
        //  menuFunctionality.SetActive(false);
        // Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        NpcPanel.SetActive(false);
        BWInteractButton.SetActive(false);
        moveScript.enabled = false;
        MinimapPanel.SetActive(false);
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
