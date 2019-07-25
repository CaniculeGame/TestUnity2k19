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


    public GameObject[] treedObj;
    private PoolObjects treeObjectPool; // pool d'arbre
    public  GameObject treeParent; // parent qui contiendra tous les objets à repeter


    private PerlinNoiseGenerator perlinNoiseGenerator; // fabrique et concerve une map 2d avec le bruit de perlin 

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


        treeObjectPool = new PoolObjects();
        treeObjectPool.SetGameObject = treedObj[0];
        treeObjectPool.SetParentGameObject = treeParent.transform;

        perlinNoiseGenerator = new PerlinNoiseGenerator();
        perlinNoiseGenerator.CalculatePerlinNoise();

    }

    /* A DEPLACER DANS GAMEPLAY , ICI ON FAIT QUE LE MONDE  */
    private void FixedUpdate()
    {
        if (game == null)
            game = GameVar.DonnerInstance();

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
        if(other.tag == "GroundEnd")
        {
            groundObjectPool.SupprimerObject(other.transform.parent.gameObject); // ground end est fils
        }
        else if(other.tag == "Tree")
        {
            treeObjectPool.SupprimerObject(other.transform.gameObject); // tree est deja le parent
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GroundEnd")
        {
            // generation de la route
            groundObjectPool.CreerObject(other.transform.position, Quaternion.identity);

            // generation du decors
            Vector3 positionDebut = other.transform.position;
            float size = groundObj.GetComponentInChildren<Renderer>().bounds.size.x;
            Vector3 positionFin = new Vector3(positionDebut.x + size, positionDebut.y, positionDebut.z);

            //quand on cree un chemin on va placer des objets le long du terrain precedement generé 
            /*    perlinNoiseGenerator.PositionPerlinMap = new Vector2(Random.Range(0, perlinNoiseGenerator.Largeur), Random.Range(1,perlinNoiseGenerator.Hauteur - size));
                for (int x = 0; x < size; x++)
                {
                    Vector2 position = perlinNoiseGenerator.PositionPerlinMap;
                    Vector3 positionNouveauObj = other.transform.position;
                    float val = perlinNoiseGenerator.ValeurPosition;

                    perlinNoiseGenerator.PositionPerlinMap = new Vector2(position.x, position.y + 1);  //OnTriggerEnter incremente la position

                    if (val*10 > 2f)
                    {
                        positionNouveauObj = new Vector3(position.x + Random.Range(0,size), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
                        treeObjectPool.CreerObject(other.transform.position, Quaternion.identity);
                    }
                }*/
        }
    }
}
