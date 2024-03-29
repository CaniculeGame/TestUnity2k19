﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTest;

public class GenerateWorld : MonoBehaviour
{
    /* ground principal */
    public GameObject groundObj;    // objet a repeter
    public GameObject groundParent; // parent qui contiendra tous les objets à repeter
    private PoolObjects groundObjectPool; // pool de ground


    public GameObject[] treedObj;
    private PoolObjects treeObjectPool; // pool d'arbre
    private PoolObjects treeObjectPool2; // pool d'arbre
    private PoolObjects treeObjectPool3; // pool d'arbre
    private PoolObjects grassObjectPool; // pool d'herbe
    public  GameObject treeParent; // parent qui contiendra tous les objets à repeter


    private PerlinNoiseGenerator perlinNoiseGenerator; // fabrique et concerve une map 2d avec le bruit de perlin 

    
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


        treeObjectPool = new PoolObjects();
        treeObjectPool.SetGameObject = treedObj[0];
        treeObjectPool.SetParentGameObject = treeParent.transform;

        treeObjectPool2 = new PoolObjects();
        treeObjectPool2.SetGameObject = treedObj[1];
        treeObjectPool2.SetParentGameObject = treeParent.transform;

        treeObjectPool3 = new PoolObjects();
        treeObjectPool3.SetGameObject = treedObj[2];
        treeObjectPool3.SetParentGameObject = treeParent.transform;

        grassObjectPool = new PoolObjects();
        grassObjectPool.SetGameObject = treedObj[3];
        grassObjectPool.SetParentGameObject = treeParent.transform;

        perlinNoiseGenerator = new PerlinNoiseGenerator();
        perlinNoiseGenerator.Echelle = 99f;
        perlinNoiseGenerator.CalculatePerlinNoise();
    }


    public void Initialiser()
    {
        // "detruire" tous les objets affiché
        foreach(Transform go in groundParent.GetComponentInChildren<Transform>())
        {
            SupprimerObjet(go.gameObject);
        }

        // place le premier
        groundObjectPool.CreerObject(new Vector3(0, -0.5f, 3), Quaternion.identity);

    }


    private void SupprimerObjet(GameObject other)
    {
        if (other.tag == "GroundEnd")
        {
            groundObjectPool.SupprimerObject(other.transform.parent.gameObject); // ground end est fils
        }
        else if (other.tag == "Tree1")
        {
            treeObjectPool.SupprimerObject(other.gameObject); // tree est deja le parent
        }
        else if (other.tag == "Tree2")
        {
            treeObjectPool2.SupprimerObject(other.gameObject); // tree est deja le parent
        }
        else if (other.tag == "Tree3")
        {
            treeObjectPool3.SupprimerObject(other.gameObject); // tree est deja le parent
        }
        else if (other.tag == "grass")
        {
            grassObjectPool.SupprimerObject(other.gameObject); // grass est deja le parent
        }
        else if (other.tag == "PlayerCar")
        {
            other.transform.gameObject.SetActive(false);
        }
    }


    void OnTriggerExit(Collider other)
    {
        SupprimerObjet(other.gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GroundEnd")
        {
            // generation de la route
            groundObjectPool.CreerObject(other.transform.position, Quaternion.identity);

            // generation du decors
            Vector3 positionDebut = other.transform.parent.position;
            float size = groundObj.GetComponentInChildren<Renderer>().bounds.size.x*3;
            //quand on cree un chemin on va placer des objets le long du terrain precedement generé 

            /* GENERATION DU MONDE*/
            int nbMax = Random.Range(1, 10);
            Vector3 position;
            for (int i = 0; i < nbMax; i++)
            {
                float valeur = perlinNoiseGenerator.ValeurPosition;
                Vector2 pos = perlinNoiseGenerator.PositionPerlinMap;
                if (valeur < 0.05)
                {

                }
                else if (valeur < 0.25f)
                {
                    position = new Vector3((positionDebut.x + Random.Range(0f, size)), (-1) * Random.Range(0.3f, 1f), Random.Range(8, 12));
                    treeObjectPool3.CreerObject(position, Quaternion.identity);
                }
                else if (valeur < 0.5f)
                {
                    position = new Vector3((positionDebut.x + Random.Range(0f, size)), (-1) * Random.Range(0.3f, 1f), Random.Range(8, 12));
                    treeObjectPool2.CreerObject(position, Quaternion.identity);
                }
                else if (valeur < 0.8f)
                {
                    position = new Vector3((positionDebut.x + Random.Range(0f, size)), (-1) * Random.Range(0.3f, 1f), Random.Range(8, 12));
                    treeObjectPool.CreerObject(position, Quaternion.identity);
                }
                perlinNoiseGenerator.PositionPerlinMap = new Vector2((pos.x + 1) % 256, pos.y);
            }


            for (int i = 0; i < 15; i++)
            {
                float valeur = perlinNoiseGenerator.ValeurPosition;
                Vector2 pos = perlinNoiseGenerator.PositionPerlinMap;
                position = new Vector3((positionDebut.x + Random.Range(0f, size)), (-1) * Random.Range(0.3f, 1f), Random.Range(3, 12));
                grassObjectPool.CreerObject(position, Quaternion.identity);
                perlinNoiseGenerator.PositionPerlinMap = new Vector2((pos.x + 1) % 256, pos.y);
            }
        }
    }
}
