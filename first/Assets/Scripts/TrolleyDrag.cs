using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class TrolleyDrag : MonoBehaviour
{
    IEnumerator coroutine;
    
    public GameObject ReduceText;

    public GameObject ReplayButton;

    // Start is called before the first frame update
    void Start()
    {
        ReduceText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(DragController.timer<=0 && ReplayButton.activeInHierarchy==false)
        {
            ReplayButton.SetActive(true);
        }

        if (DragController.timer <= 0)
        {
            DragController.timer = 0.5f;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pie")
        {

            
            DragController.timer -= 2;

            ReduceText.SetActive(true);

            coroutine = pausetime(2.0f);

            StartCoroutine(coroutine);
        }
    }

    IEnumerator pausetime(float waitTime)
    {
       
        yield return new WaitForSeconds(waitTime);

        ReduceText.SetActive(false);
      
    }

    public void GameReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Application.LoadLevel(0);


    }


}
