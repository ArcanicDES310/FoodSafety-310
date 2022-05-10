using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class DragController : MonoBehaviour
{


    public static float timer=45;
    public GameObject GamePanel;
    public int thrownPies = 0; //thrownTrays = 0;

    public Text timerText;
    bool hasWon;

    DragController dragScript;

    public GameObject ReduceText;


    IEnumerator coroutine;



    void Awake()
    {
        DragController[] controller = FindObjectsOfType<DragController>();
        if (controller.Length > 1)
        {
            Destroy(gameObject);

        }

    }

    void Start()
    {

        PlayerPrefs.SetInt("playedOnce", 1);

        hasWon = false;
        thrownPies = 0;
        timer = 45;
      
        GamePanel.SetActive(false);
        
        dragScript = GetComponent<DragController>();
        dragScript.enabled = true;
        Time.timeScale = 1;
    }

    void Update()
    {


        if (thrownPies >= 16 && TrolleyDrag.thrownTrays >= 8)
        {
            winState();
        }

        if (hasWon == false)
        {
            timer -= Time.deltaTime;
            int temp = (int)timer;
            timerText.text = temp.ToString();
        }

        

        if(timer<=0)
        {
            Time.timeScale = 0;
            dragScript.enabled = false;
        }
         

  


        
    }

    public void winState()
    {
        GamePanel.SetActive(true);
        hasWon = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pie")
        { 

            collision.gameObject.SetActive(false);

            thrownPies++;

          // if(thrownPies>=3 && thrownTrays>0)
          // {
          //     winState();
          // }
        }

        if(collision.gameObject.tag=="Tray")
        {

            

            timer -= 2;

            ReduceText.SetActive(true);

            coroutine = pausetime(2.0f);

            StartCoroutine(coroutine);

           // thrownTrays++;

        }


    }

    IEnumerator pausetime(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);

        ReduceText.SetActive(false);

    }

    public void ExitButton()
    {
        SceneManager.LoadScene(1);
    }


}

