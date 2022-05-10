using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement2 : MonoBehaviour
{

    private CharacterController m_charCont;

    float m_horizontal;
    float m_vertical;



    
   
    public float PlayerSpeed = 0.03f;
    public float rotationSpeed;
    public Animator animator;
    public GameObject ovenCollider;
    public GameObject lockerCollider;

    //Panels
    public GameObject GamePanelOven;
    public GameObject GamePanelLocker;
    public GameObject NpcPanel;
    public GameObject BWInteractButton;

    //Objectives checkbox
    public GameObject OvenCheck;
    public GameObject LockerCheck;




    void Start()
    {

        Time.timeScale = 1;


        if(PlayerPrefs.GetInt("playedOnce",0)==1)
        {

            ovenCollider.SetActive(false);
            OvenCheck.SetActive(true);


        }

        transform.position = new Vector3(PlayerPrefs.GetFloat("xPos", 0), PlayerPrefs.GetFloat("yPos", 0), PlayerPrefs.GetFloat("zPos", 0));

        if(PlayerPrefs.GetInt("hasPlayed",0)==1)
        {
            lockerCollider.SetActive(false);
            LockerCheck.SetActive(true);
        }
       


        m_charCont = GetComponent<CharacterController>();
       
        animator = GetComponent<Animator>();


    }

    void Update()
    {
        m_horizontal = Input.GetAxis("Horizontal");
        m_vertical = Input.GetAxis("Vertical");

        Vector3 m_playerMovement = new Vector3(m_horizontal, 0f, m_vertical).normalized * PlayerSpeed; 

        m_charCont.Move(m_playerMovement);

        if (m_playerMovement != Vector3.zero)
        {
            animator.SetBool("isWalking", true);

            Quaternion toRotation = Quaternion.LookRotation(m_playerMovement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else animator.SetBool("isWalking", false);
           
    }

   private void OnTriggerEnter(Collider other)
   {
  
       if (other.gameObject.tag == "ovenCollider")
       {
            GamePanelOven.SetActive(true);
       }

       if(other.gameObject.tag=="LockerCollider")
       {
            GamePanelLocker.SetActive(true);

       }

       if (other.gameObject.tag=="NpcCollider")
       {

            NpcPanel.SetActive(true);
            BWInteractButton.SetActive(false);

        }

     

        
  
   }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ovenCollider")
        {
            GamePanelOven.SetActive(false);
        }

        if(other.gameObject.tag=="LockerCollider")
        {
            GamePanelLocker.SetActive(false);
        }

        if (other.gameObject.tag == "NpcCollider")
        {

            NpcPanel.SetActive(false);
            BWInteractButton.SetActive(true);

        }

     
    }

    public void ovenGameStart()
    {

        PlayerPrefs.SetFloat("xPos", transform.position.x);
        PlayerPrefs.SetFloat("yPos", transform.position.y);
        PlayerPrefs.SetFloat("zPos", transform.position.z);


        SceneManager.LoadScene(2);
    }

    public void lockerGameStart()
    {

        PlayerPrefs.SetFloat("xPos", transform.position.x);
        PlayerPrefs.SetFloat("yPos", transform.position.y);
        PlayerPrefs.SetFloat("zPos", transform.position.z);


        SceneManager.LoadScene(3);
    }

    public void resetkeys()
    {
        PlayerPrefs.DeleteAll();
    }


}