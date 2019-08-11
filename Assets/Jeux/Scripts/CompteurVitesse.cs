using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTest;

public class CompteurVitesse : MonoBehaviour
{
    private Vector3 lastPosition;
    public float facteurDistance = 1;
    public Transform referentiel;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = referentiel.transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        CalculDistanceParcourue();
    }


    public void ChangerReferentiel(Transform nouveauReferentiel)
    {
        if (nouveauReferentiel == null)
            return;

        referentiel = nouveauReferentiel;
    }

    private void CalculDistanceParcourue()
    {
        float dist = Vector3.Distance(referentiel.transform.position, lastPosition);
        GameVar.DonnerInstance().DistanceParcourue += dist * facteurDistance;
        lastPosition = referentiel.transform.position;
    }

}
