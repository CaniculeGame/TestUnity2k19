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
        Initialiser();
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
        if (GameVar.DonnerInstance().GamePlayState != GameVar.GAME_STATES.GAME_STATES_PLAY)
            return;

        float dist = Vector3.Distance(referentiel.transform.position, lastPosition);
        GameVar.DonnerInstance().DistanceParcourue += dist * facteurDistance;
        lastPosition = referentiel.transform.position;
    }

    public void Initialiser()
    {
        lastPosition = referentiel.transform.position;
        GameVar.DonnerInstance().DistanceParcourue = 0;
    }

}
