using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine;
using UnityTest;

public class GamePlayStart : GamePlay 
{
    public GameObject guiPause;
    public GameObject guiGeneral;
    public GameObject guiCar;
    public GameObject guiRabbit;
    public GameObject guiTuTo;

    public GameObject animal;
    public GameObject[] animalsList;
    public GameObject car;
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
        guiPause.gameObject.SetActive(false);
        guiRabbit.gameObject.SetActive(false);
        guiTuTo.gameObject.SetActive(false);
        guiGeneral.gameObject.SetActive(false);
        guiCar.transform.GetChild(0).gameObject.SetActive(false);
        guiCar.transform.GetChild(2).gameObject.SetActive(true);
        guiCar.transform.GetChild(1).GetComponent<SliderPower>().Initialisation();

        game.Initialiser();
        camera.GetComponent<CompteurVitesse>().ChangerReferentiel(car.transform);
        camera.GetComponent<CompteurVitesse>().Initialiser();
    }

    private void ChargerAnimal()
    {
        //chargement de l'animal choisi
        int petId = PlayerPrefs.GetInt("PetId");
        GameObject mesh = GameObject.Instantiate(animalsList[petId], Vector3.zero, Quaternion.identity);
        // positionnement de l'animal
        mesh.transform.parent = animal.transform;
        animal.transform.position = Vector3.zero;
        mesh.transform.position = Vector3.zero;
        mesh.transform.rotation = Quaternion.identity;
        mesh.transform.Rotate(new Vector3(0, 180, 0));
    }

    private void Start()
    {
        ChargerAnimal();
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
