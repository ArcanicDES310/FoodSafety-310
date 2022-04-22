using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject player;        //Public variable to store a reference to the player game object


   // public Transform t_camera;

    private Vector3 offset;            //Private variable to store the offset distance between the player and camera
   // private RaycastHit hit;
   // private Vector3 camera_offset;




    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
       // camera_offset = t_camera.localPosition;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;

      //  if(Physics.Linecast(transform.position,t_camera.position,out hit))
      //  {
      //
      //      t_camera.localPosition = new Vector3(0, 0, -Vector3.Distance(transform.position, hit.point));
      //
      //  }
      //  else
      //  {
      //      
      //      t_camera.localPosition = Vector3.Lerp(t_camera.localPosition, offset, Time.deltaTime);
      //  }


       
    }

  
}