using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class DragController : MonoBehaviour
{

    private bool _isDragActive = false;

    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private Draggable _lastDragged;


    public GameObject pie1;
    public GameObject pie2;
    public GameObject pie3;
    GameObject pies;
    public static float timer=20;
    public GameObject GamePanel;
    public int thrownPies = 0;

    public Text timerText;
    bool hasWon;

    DragController dragScript;




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
        timer = 20;
        pies = GameObject.FindGameObjectWithTag("Pie");
        GamePanel.SetActive(false);
        
        dragScript = GetComponent<DragController>();
        dragScript.enabled = true;
        Time.timeScale = 1;
    }

    void Update()
    {
        pie1.transform.position = new Vector2(Mathf.Clamp(pie1.transform.position.x, -8.8f, 8.8f), Mathf.Clamp(pie1.transform.position.y, -5f, 5f));
        pie2.transform.position = new Vector2(Mathf.Clamp(pie2.transform.position.x, -8.8f, 8.8f), Mathf.Clamp(pie2.transform.position.y, -5f, 5f));
        pie3.transform.position = new Vector2(Mathf.Clamp(pie3.transform.position.x, -8.8f, 8.8f), Mathf.Clamp(pie3.transform.position.y, -5f, 5f));

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

            if(thrownPies>=3)
            {
                winState();
            }
        }


    }

    public void ExitButton()
    {
        SceneManager.LoadScene(1);
    }


}

