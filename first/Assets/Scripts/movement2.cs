using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement2 : MonoBehaviour
{

    private CharacterController m_charCont;

    float m_horizontal;
    float m_vertical;



    public GameObject infoPanel;
    public GameObject miniPanel;
    public float PlayerSpeed = 0.03f;
    public float rotationSpeed;
    public Animator animator;
    public GameObject ovenCollider;

    public GameObject GamePanelOven;
    void Start()
    {
       // PlayerPrefs.DeleteAll();

        if(PlayerPrefs.GetInt("playedOnce",0)==1)
        {

            ovenCollider.SetActive(false);

        }

        transform.position = new Vector3(PlayerPrefs.GetFloat("xPos", 0), PlayerPrefs.GetFloat("yPos", 0), PlayerPrefs.GetFloat("zPos", 0));


        m_charCont = GetComponent<CharacterController>();
        miniPanel.SetActive(false);
        animator = GetComponent<Animator>();


       // PlayerPrefs.GetFloat("xPos", 0);
       // PlayerPrefs.GetFloat("yPos", 0);
       // PlayerPrefs.GetFloat("zPos", 0);

       // transform.position = new Vector3(PlayerPrefs.GetFloat("xPos", 0), PlayerPrefs.GetFloat("yPos", 0), PlayerPrefs.GetFloat("zPos", 0));
    }

    void Update()
    {
        m_horizontal = Input.GetAxis("Horizontal");
        m_vertical = Input.GetAxis("Vertical");

        Vector3 m_playerMovement = new Vector3(m_horizontal, 0f, m_vertical) * PlayerSpeed;

        m_charCont.Move(m_playerMovement);

        if (m_playerMovement != Vector3.zero)
        {
            animator.SetBool("isWalking", true);

            Quaternion toRotation = Quaternion.LookRotation(m_playerMovement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else animator.SetBool("isWalking", false);
           
    }

  


    private void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.tag=="npc")
        {
            infoPanel.SetActive(true);
        }
    }

    

   private void OnTriggerEnter(Collider other)
   {
  
       if (other.gameObject.tag == "ovenCollider")
       {
            GamePanelOven.SetActive(true);
       }
  
   }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ovenCollider")
        {
            GamePanelOven.SetActive(false);
        }

    }



    public void ovenGameStart()
    {

        PlayerPrefs.SetFloat("xPos", transform.position.x);
        PlayerPrefs.SetFloat("yPos", transform.position.y);
        PlayerPrefs.SetFloat("zPos", transform.position.z);


        SceneManager.LoadScene(2);


    }

    public void resetkeys()
    {

        PlayerPrefs.DeleteAll();


    }


}