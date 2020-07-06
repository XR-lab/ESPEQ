using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class JoystickControll : MonoBehaviour
    {

         public Transform topOfJoystick;

         public float forwardBackwardTilt = 0;

         public float sideToSideTilt = 0;

        void Update()
        {
            forwardBackwardTilt = topOfJoystick.rotation.eulerAngles.x;
            Debug.Log(topOfJoystick.localRotation.x);
            if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
            {
                forwardBackwardTilt = Math.Abs(forwardBackwardTilt - 360);
                Debug.Log("backward"+ forwardBackwardTilt);
            }
            else if (forwardBackwardTilt > 5 && forwardBackwardTilt < 74)
            {
                Debug.Log("forward"+ forwardBackwardTilt);
            }

            sideToSideTilt = topOfJoystick.rotation.eulerAngles.z;
            if (sideToSideTilt < 355 && sideToSideTilt > 290)
            {
                sideToSideTilt = Math.Abs(sideToSideTilt - 360);
                Debug.Log("right" + sideToSideTilt);
            }
            else if (sideToSideTilt > 5 && sideToSideTilt < 74)
            {
              Debug.Log("left" + sideToSideTilt);
            }
            
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Hand"))
            {
                transform.LookAt(other.transform.position, transform.up);
            }
        }
        
    }
    

