using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTest;

public class CompteurVitesse : MonoBehaviour
{
    private Vector3 lastPosition;
    public float facteurDistance = 1;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = this.transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        CalculDistanceParcourue();
    }


    private void CalculDistanceParcourue()
    {
        float dist = Vector3.Distance(this.transform.position, lastPosition);
        GameVar.DonnerInstance().DistanceParcourue += dist * facteurDistance;
        lastPosition = this.transform.position;
    }

#if UNITY_EDITOR
    private void OnGUI()
    {

        string str = "Distance : " + GameVar.DonnerInstance().DistanceParcourue.ToString() + " m";
        GUI.TextField(new Rect(10, 0, 200, 20), str);

    }
#endif
}
