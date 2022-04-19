//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using CodeMonkey.Utils;
//using CodeMonkey;

namespace followCam
{

    public class GameHandler : MonoBehaviour
    {

        [SerializeField] private CameraFollow cameraFollow;
        Vector3 cameraFollowPosition;


        private void Start()
        {

            cameraFollow.Setup(() => cameraFollowPosition, () => 80f);
            
        }

        private void Update()
        {

            float edgeSize = 500f;

            float moveAmount = 5f;

         
            if (Input.GetKey(KeyCode.A))
            {

                cameraFollowPosition.x -= moveAmount * Time.deltaTime;

            }


            if (Input.GetKey(KeyCode.D))
            {

                cameraFollowPosition.x += moveAmount * Time.deltaTime;

            }



           // float edgeSize = 500f;

            if (Input.mousePosition.x>Screen.width-edgeSize)
            {

                cameraFollowPosition.x += moveAmount * Time.deltaTime;

            }

            if (Input.mousePosition.x < edgeSize)
            {

                cameraFollowPosition.x -= moveAmount * Time.deltaTime;

            }




        }
    }

       

}