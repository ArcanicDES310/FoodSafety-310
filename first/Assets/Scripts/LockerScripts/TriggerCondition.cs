using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerCondition : MonoBehaviour
{
    //Character
    public GameObject boots;
    public GameObject coat;
    public GameObject glove;
    public GameObject cap;
    public GameObject lockerShoe;
    public GameObject handwash1;
    public GameObject handwash2;


    //Environment
   

    public GameObject placeBoot;
    public GameObject placeCoat;
    public GameObject placeGlove;
    public GameObject placeCap;


    //
    public static int taskCount = 7;
    public Text taskCounter;
    

   

    //Buttons
    public GameObject exitButton;
  

    private void Start()
    {

        PlayerPrefs.SetInt("hasPlayed", 1);


        boots.SetActive(false);
        coat.SetActive(false);
        glove.SetActive(false);
        cap.SetActive(false);

        taskCounter.text = taskCount.ToString();


        

    }

    private void Update()
    {

        taskCounter.text = taskCount.ToString();

       
       

        if(boots.activeInHierarchy && coat.activeInHierarchy && glove.activeInHierarchy && cap.activeInHierarchy && lockerShoe.activeInHierarchy &&  handwash1==null && handwash2==null) //!handwash1.activeInHierarchy && !handwash2.activeInHierarchy)
        {

            
            exitButton.SetActive(true);
            Time.timeScale = 0;
        }

        placeBoot.transform.position = new Vector2(Mathf.Clamp(placeBoot.transform.position.x,-17.5f,17.5f),Mathf.Clamp(placeBoot.transform.position.y,-4.1f,4.1f));
        placeCoat.transform.position = new Vector2(Mathf.Clamp(placeCoat.transform.position.x, -17.5f, 17.5f), Mathf.Clamp(placeCoat.transform.position.y, -4.1f, 4.1f));
        placeGlove.transform.position = new Vector2(Mathf.Clamp(placeGlove.transform.position.x, -17.5f, 17.5f), Mathf.Clamp(placeGlove.transform.position.y, -4.1f, 4.1f));
        placeCap.transform.position = new Vector2(Mathf.Clamp(placeCap.transform.position.x, -17.5f, 17.5f), Mathf.Clamp(placeCap.transform.position.y, -4.1f, 4.1f));


        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Boots")
        {
            boots.SetActive(true);
            placeBoot.SetActive(false);
            taskCount--;
            
        }

        if (collision.gameObject.tag == "Coat")
        {
            coat.SetActive(true);
            placeCoat.SetActive(false);
            taskCount--;

        }

        if (collision.gameObject.tag == "Gloves")
        {
            glove.SetActive(true);
            placeGlove.SetActive(false);
            taskCount--;

        }

        if (collision.gameObject.tag == "HairCap")
        {
            cap.SetActive(true);
            placeCap.SetActive(false);
            taskCount--;

        }
       

    }

    public void exitAction()
    {
        SceneManager.LoadScene(1);
    }


}
