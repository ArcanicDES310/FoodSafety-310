using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript2 : MonoBehaviour
{
   // public GameObject OpenDoor;
    public GameObject OpenDoor2;
   // public GameObject PlaceCoat;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnMouseDown()
    {
        gameObject.SetActive(false);

        //gameObject.SetActive(false);
        //  PlaceCoat.SetActive(true);
        //  OpenDoor.SetActive(true);
        OpenDoor2.SetActive(true);
       // gameObject.SetActive(false);

    }
}
