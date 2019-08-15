using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine;
using UnityTest;

public class GamePlayStart : GamePlay 
{
    public GameObject guiPause;
    public GameObject guiGameOver;
    public GameObject guiGeneral;
    public GameObject guiCar;
    public GameObject guiRabbit;
    public GameObject guiTuTo;

    public GameObject animal;
    public GameObject[] animalsList;
    public GameObject car;
    public GameObject[] carsList;
    public Camera camera;
    public GameObject world;
    public GameVar.GAME_STATES st;

    public override void Initialiser()
    {
        /* *rien a faire puisque c'est nous qui appelont toutes les autres*/
    }


    private void Init()
    {
        Verification();
        timeManager.Initialiser();

        car.GetComponent<CarUserControl>().Initialiser();
        animal.GetComponent<PlayerController>().Initialiser();
        world.GetComponent<GenerateWorld>().Initialiser();
        world.GetComponent<GenerateWorld>().Initialiser();
        camera.GetComponent<CameraRunner>().ReinitialiserPlayer();


        //reinit Gui
        guiGameOver.gameObject.SetActive(false);
        guiPause.gameObject.SetActive(false);
        guiRabbit.gameObject.SetActive(false);
        guiTuTo.gameObject.SetActive(false);
        guiGeneral.gameObject.SetActive(false);
        guiCar.transform.GetChild(0).gameObject.SetActive(false);
        guiCar.transform.GetChild(2).gameObject.SetActive(true);
        guiCar.transform.GetChild(3).gameObject.SetActive(false);
        guiCar.transform.GetChild(1).GetComponent<SliderPower>().Initialisation();

        game.Initialiser();
        camera.GetComponent<CompteurVitesse>().ChangerReferentiel(car.transform);
        camera.GetComponent<CompteurVitesse>().Initialiser();
    }

    private void ChargerAnimal()
    {
        //chargement de l'animal choisi
#if UNITY_EDITOR
        int petId = 0;
#else
        int petId = PlayerPrefs.GetInt("PetId");
#endif
        GameObject mesh = GameObject.Instantiate(animalsList[petId], Vector3.zero, Quaternion.identity);
        // positionnement de l'animal
        mesh.transform.parent = animal.transform;
        animal.transform.position = Vector3.zero;
        mesh.transform.position = Vector3.zero;
        mesh.transform.rotation = Quaternion.identity;
        mesh.transform.Rotate(new Vector3(0, 180, 0));
    }

    private void ChargerVoiture()
    {
        //chargement de la voiture choisi
#if UNITY_EDITOR
        int carId =3; // 0,2,3,4,5,6, -0.7   1 : -0.1
#else
       int carId = PlayerPrefs.GetInt("CarId");
#endif
        // c'est pas tres beau
        float y = -0.7f;
        if (carId == 1)
            y = -0.1f;

        GameObject mesh = GameObject.Instantiate(carsList[carId], Vector3.zero, Quaternion.identity);

        mesh.transform.parent = car.transform;
       // mesh.transform.rotation = Quaternion.identity;
        mesh.transform.Rotate(new Vector3(0, 90, 0));
        mesh.transform.position = new Vector3(0,0,0);
        car.transform.GetChild(0).position = new Vector3(0, y, 0);
        car.GetComponent<CarController>().RechargerWheelMesh();
    }

    private void Start()
    {
        ChargerAnimal();
        ChargerVoiture();
        Init();
    }


    private void Update()
    {
       
        Verification();
        st = game.GamePlayState;
        if (game.GamePlayState != GameVar.GAME_STATES.GAME_STATES_START)
            return;

        //reinit jeu
        Init();

        //lance animation
        // a la fin de l animation, on change d'etat et on active les gui
        game.GamePlayState = GameVar.GAME_STATES.GAME_STATES_PLAY;
        guiGeneral.gameObject.SetActive(true);
        guiCar.gameObject.SetActive(true);
    }

}
