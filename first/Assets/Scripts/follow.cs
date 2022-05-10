using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject player;        //Public variable to store a reference to the player game object


   // public Transform t_camera;

    private Vector3 offset;     //Private variable to store the offset distance between the player and camera


  //  public Transform Player, Target;

   


   // public Transform Obstruction;
   // float zoomSpeed = 2f;
   //
  




    // Use this for initialization
    void Start()

        
    {

        //Obstruction = Target;
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
      
    }


  

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {


        transform.position = player.transform.position + offset;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -85.5f, 57.13f), transform.position.y, Mathf.Clamp(transform.position.z, -44f, 58.4f));


       // ViewObstructed();
       


    }

  //  void ViewObstructed()
  //  {
  //      RaycastHit hit;
  //
  //      if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, 4.5f))
  //      {
  //          if (hit.collider.gameObject.tag != "Player")
  //          {
  //              Obstruction = hit.transform;
  //              Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
  //
  //              if (Vector3.Distance(Obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, Target.position) >= 1.5f)
  //                  transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
  //          }
  //          else
  //          {
  //              Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
  //              if (Vector3.Distance(transform.position, Target.position) < 4.5f)
  //                  transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
  //          }
  //      }
  //  }


}