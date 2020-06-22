using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lever
{
    public class JoystickControll : MonoBehaviour
    {

         public Transform topOfJoystick;

         public float forwardBackwardTilt = 0;

           // public float sideToSideTilt = 0;

        void Update()
        {
            forwardBackwardTilt = topOfJoystick.rotation.eulerAngles.x;
            if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
            {
                forwardBackwardTilt = Math.Abs(forwardBackwardTilt - 360);

            }
            else if (forwardBackwardTilt > 5 && forwardBackwardTilt < 74)
            {

            }

            /*sideToSideTilt = topOfJoystick.rotation.eulerAngles.z;
            if (sideToSideTilt < 355 && sideToSideTilt > 290)
            {
                sideToSideTilt = Math.Abs(sideToSideTilt - 360);

            }
            else if (sideToSideTilt > 5 && sideToSideTilt < 74)
            {
              
            }
            */
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Hand"))
            {
                transform.LookAt(other.transform.position, transform.up);
            }
            if(transform.rotation.z >= -78)
            {
                GetComponent<MovementCementStorter>();
                Debug.Log("rechts");
            }
            if(transform.rotation.z <= -101)
            {
                GetComponent<MovementCementStorter>();
                Debug.Log("links");
            }
        }
        }
    }

