using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

namespace FiveRabbitsDemo
{
    public class AnimatorParamatersChange : MonoBehaviour
    {

        private string[] m_buttonNames = new string[] { "Idle", "Run", "Dead" };

        public Animator m_animator;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.tag == "PlayerCar")
            {
                // desactive le control de la voiture
                collision.collider.GetComponentInParent<CarUserControl>().enabled = false;
                collision.collider.GetComponentInParent<CarController>().enabled = false;

                // passage du playerCar a playerAnimal
                Camera.current.GetComponent<CameraRunner>().SwitchPlayer();
                Camera.current.GetComponent<CompteurVitesse>().ChangerReferentiel(this.transform);
            }
        }

        private void OnGUI()
        {
            GUI.BeginGroup(new Rect(0, 25, 150, 1000));

            for (int i = 0; i < m_buttonNames.Length; i++)
            {
                if (GUILayout.Button(m_buttonNames[i], GUILayout.Width(150)))
                {
                    m_animator.SetInteger("AnimIndex", i);
                    m_animator.SetTrigger("Next");
                }
            }

            GUI.EndGroup();
        }
    }
}
