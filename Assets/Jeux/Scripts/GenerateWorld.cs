using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTest;

public class GenerateWorld : MonoBehaviour
{
    public Transform lastGenerated; //on garde la position de la derniere plateforme 

    private GameVar game;

    // Start is called before the first frame update
    void Start()
    {
        game = GameVar.DonnerInstance();
    }


    private void FixedUpdate()
    {
        float distanceParcourue = game.DistanceParcourue;
        if (distanceParcourue == 0.950)
        {
            // changement de gameplay
        }
        else if (distanceParcourue > 1)
        {
            // changement de gameplay
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /* repete le sol de façon infinie*/
        if(other.tag == "GroundEnd")
        {
            Transform savePos = other.transform;
            other.transform.parent.position = new Vector2(lastGenerated.transform.position.x, other.transform.position.y);
            lastGenerated = savePos;
        }
    }
}
