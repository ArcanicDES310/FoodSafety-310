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
         

        if(_isDragActive && (Input.GetMouseButtonUp(0)||(Input.touchCount==1&&Input.GetTouch(0).phase==TouchPhase.Ended)))
        {
            Drop();
            return;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    _lastDragged = draggable;
                    InitDrag();
                }



            }
        }
        void InitDrag()
        {
            _isDragActive = true;
        }

        void Drag()
        {
            _lastDragged.transform.position= new Vector2(_worldPosition.x, _worldPosition.y);
        }

        void Drop()
        {
            _isDragActive = false;
        }


        
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //    //if(collision.gameObject.tag=="Pie")
    //    //{
    //    //    Destroy(collision.gameObject);
    //    //}
    // }  //
    public void winState()
    {
        GamePanel.SetActive(true);
        hasWon = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pie")
        {
            //Destroy(collision.gameObject);

            // pies.SetActive(false);

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

