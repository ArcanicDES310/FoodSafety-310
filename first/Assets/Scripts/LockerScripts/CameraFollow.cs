using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

namespace followCam

{

    public class CameraFollow : MonoBehaviour
    {

        private Camera myCamera;
        private Func<Vector3> GetCameraFollowPositionFunc;
      
        

        public void Setup(Func<Vector3> GetCameraFollowPositionFunc, Func<float> GetCameraZoomFunc)
        {
            this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
           
        }

        private void Start()
        {
            myCamera = transform.GetComponent<Camera>();
        }

        public void SetCameraFollowPosition(Vector3 cameraFollowPosition)
        {
            SetGetCameraFollowPositionFunc(() => cameraFollowPosition);
        }

        public void SetGetCameraFollowPositionFunc(Func<Vector3> GetCameraFollowPositionFunc)
        {
            this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
        }


        
        void Update()
        {
            HandleMovement();

          

          transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.8f, 9.8f), transform.position.y,transform.position.z);


        }

        private void HandleMovement()
        {
            Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
            cameraFollowPosition.z = transform.position.z;

            Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
            float distance = Vector3.Distance(cameraFollowPosition, transform.position);
            float cameraMoveSpeed = 2f;

            if (distance > 0.1f)
            {
                Vector3 newCameraPosition = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;

                float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);

                if (distanceAfterMoving > distance)
                {
                    
                    newCameraPosition = cameraFollowPosition;
                }

                transform.position = newCameraPosition;
            }
        }

   
    }

}