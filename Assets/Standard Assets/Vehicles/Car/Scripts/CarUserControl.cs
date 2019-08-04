using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private bool leftTouch = false;

        private bool rightButton = false;
        private bool leftButton  = false;

        private void Start()
        {
            leftTouch = false;
        }

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        public void Initialiser()
        {
            this.transform.position = new Vector3(0f, -0.61f, 3f);
            this.gameObject.SetActive(true);
            this.GetComponent<CarUserControl>().enabled = true;
            this.GetComponent<CarController>().enabled = true;
            this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }

        private void FixedUpdate()
        {
            // pass the input to the car!
#if BLOUP
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
#endif

            float h = 0;


            if (Input.GetKeyUp(KeyCode.LeftArrow) && !leftTouch)
            {
                leftTouch = !leftTouch;
                h = 1;
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow) && leftTouch)
            {
                leftTouch = !leftTouch;
                h = 1;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
                h = -1;



            if (leftButton && !leftTouch)
            {
                leftTouch = !leftTouch;
                h = 1;
                leftButton = false;

            }
            else if(rightButton && leftTouch)
            {
                leftTouch = !leftTouch;
                h = 1;
                rightButton = false;
            }


            m_Car.Move(0f, h, h, 0f);

        }

        public void GuiController(Transform guiElem)
        {
            if(guiElem.name == "AccelerateurRightButton")
            {
                rightButton = true;
            }
            else if (guiElem.name == "AccelerateurLeftButton")
            {
                leftButton = true;
                leftTouch  = true;
            }
        }
    }
}
