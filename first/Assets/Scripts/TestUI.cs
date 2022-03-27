using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestUI : MonoBehaviour
{
  public void ButtonMoveScene(string level)
    {
        //public void ButtonMoveScene(string level)
            SceneManager.LoadScene(level);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
