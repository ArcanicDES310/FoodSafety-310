using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   // int resume = 0; 
   // public GameObject resumeButton;

  //public void Start()
  //{
  //    resume = PlayerPrefs.GetInt("Resume", 0);
  //    resume++;
  //
  //    PlayerPrefs.SetInt("Resume", resume);
  //
  //    //PlayerPrefs.SetInt("Resume", 0);
  //    if (PlayerPrefs.GetInt("Resume",0)>1)
  //
  //    {
  //
  //        resumeButton.SetActive(true);
  //
  //    }
  //
  //   // resume++;
  //
  //   // PlayerPrefs.SetInt("Resume", resume);
  //}
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {

        Debug.Log("Exit Done");

         Application.Quit();
    }

    public void newGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
