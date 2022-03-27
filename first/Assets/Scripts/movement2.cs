using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour
{

    private CharacterController m_charCont;

    float m_horizontal;
    float m_vertical;

    public GameObject miniPanel;
    public float PlayerSpeed = 0.03f;
    public float rotationSpeed;
    public Animator animator;
    void Start()
    {
        m_charCont = GetComponent<CharacterController>();
        miniPanel.SetActive(false);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        m_horizontal = Input.GetAxis("Horizontal");
        m_vertical = Input.GetAxis("Vertical");

        Vector3 m_playerMovement = new Vector3(m_horizontal, 0f, m_vertical) * PlayerSpeed;

        m_charCont.Move(m_playerMovement);

        if (m_playerMovement != Vector3.zero)
        {
            animator.SetBool("isMoving", true);

            Quaternion toRotation = Quaternion.LookRotation(m_playerMovement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else animator.SetBool("isMoving", false);
           
    }


   
    // Testing for github desktop
   
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag=="machine")
    //    {
    //        miniPanel.SetActive(true);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "machine")
        {
            miniPanel.SetActive(true);
        }
    }
}
