using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTest;

public class GenerateWorld : MonoBehaviour
{
    public GameObject groundObj;    // objet a repeter
    public GameObject groundParent; // parent qui contiendra tous les objets à repeter

    public Transform   lastGenerated; //on garde la position de la derniere plateforme 
    public TimeManager timeMnager;    //ralentie le temps 
    
    private GameVar game;
    private PoolObjects groundObjectPool;

    // Start is called before the first frame update
    void Start()
    {
        game = GameVar.DonnerInstance();
        groundObjectPool = new PoolObjects();
        groundObjectPool.SetGameObject = groundObj;
        groundObjectPool.SetParentGameObject = groundParent.transform;
        groundObjectPool.CreerObject(new Vector3(0, 0, 3), Quaternion.identity);
        groundObjectPool.CreerObject(new Vector3(30.3f, 0, 3), Quaternion.identity);

    }


    private void FixedUpdate()
    {
        float distanceParcourue = game.DistanceParcourue;
        if (distanceParcourue > 50 && distanceParcourue  < 55 )
        {
            //passage en slowmotion pour tous le monde
            timeMnager.DoSlowmotion();

            // changement de gameplay
        }
        else if (distanceParcourue > 55)
        {
            //sortie du slowmotion
            timeMnager.StopSlowMotion();

            // changement de gameplay
        }
    }

    void OnTriggerEnter(Collider other)
    {
        /* repete le sol de façon infinie*/
        if (other.tag == "GroundEnd")
        {
            Transform savePos = other.transform;
            groundObjectPool.CreerObject(savePos.position, Quaternion.identity);
            groundObjectPool.SupprimerObject(other.transform.parent.gameObject);
        }
    }
}
