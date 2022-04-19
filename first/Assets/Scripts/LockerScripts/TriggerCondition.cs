using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCondition : MonoBehaviour
{
    //Character
    public GameObject boots;
    public GameObject coat;
    public GameObject glove;
    public GameObject cap;
    public GameObject lockerShoe;


    //Environment
   

    public GameObject placeBoot;
    public GameObject placeCoat;
    public GameObject placeGlove;
    public GameObject placeCap;

    public GameObject exitButton;

    private void Start()
    {

        PlayerPrefs.SetInt("hasPlayed", 1);


        boots.SetActive(false);
        coat.SetActive(false);
        glove.SetActive(false);
        cap.SetActive(false);
        

    }

    private void Update()
    {

        if(boots.activeInHierarchy && coat.activeInHierarchy && glove.activeInHierarchy && cap.activeInHierarchy && lockerShoe.activeInHierarchy)
        {

            exitButton.SetActive(true);

        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Boots")
        {
            boots.SetActive(true);
            placeBoot.SetActive(false);
        }

        if (collision.gameObject.tag == "Coat")
        {
            coat.SetActive(true);
            placeCoat.SetActive(false);
        }

        if (collision.gameObject.tag == "Gloves")
        {
            glove.SetActive(true);
            placeGlove.SetActive(false);
        }

        if (collision.gameObject.tag == "HairCap")
        {
            cap.SetActive(true);
            placeCap.SetActive(false);
        }
       

    }

    public void exitAction()
    {
        SceneManager.LoadScene(1);
    }


}
