using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTest;

public class GenerateWorld : MonoBehaviour
{
    /* ground principal */
    public GameObject groundObj;    // objet a repeter
    public GameObject groundParent; // parent qui contiendra tous les objets à repeter
    private PoolObjects groundObjectPool; // pool de ground

    public TimeManager timeMnager;    //gestion dsu slow motion 
    
    private GameVar game;


    // Start is called before the first frame update
    void Start()
    {
        game = GameVar.DonnerInstance();

        // placement des premiers block 
        groundObjectPool = new PoolObjects();
        groundObjectPool.SetGameObject = groundObj;
        groundObjectPool.SetParentGameObject = groundParent.transform;
        groundObjectPool.CreerObject(new Vector3(0, -0.5f, 3), Quaternion.identity);
    }

    /* A DEPLACER DANS GAMEPLAY , ICI ON FAIT QUE LE MONDE  */
    private void FixedUpdate()
    {
        float distanceParcourue = game.DistanceParcourue;
        if (distanceParcourue > 250 && distanceParcourue  < 255 )
        {
            //passage en slowmotion pour tous le monde
            timeMnager.DoSlowmotion();

            // changement de gameplay
        }
        else if (distanceParcourue > 255)
        {
            //sortie du slowmotion
            timeMnager.StopSlowMotion();

            // changement de gameplay
        }
    }

    void OnTriggerExit(Collider other)
    {
        /* repete le sol de façon infinie*/
        if (other.tag == "GroundEnd")
        {
            groundObjectPool.SupprimerObject(other.transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GroundEnd")
        {
            groundObjectPool.CreerObject(other.transform.position, Quaternion.identity);
        }
    }
}
