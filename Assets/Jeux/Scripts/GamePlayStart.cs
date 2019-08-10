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

    public GameObject rabbit;
    public GameObject car;
    public Camera camera;
    public GameObject world;
    public GameVar.GAME_STATES st;

    public override void Initialiser()
    {
        /* *rien a faire puisque c'est nous qui appelont toutes les autres*/
        if (rabbit == null)
            rabbit = GameObject.Find("rabbit");

        if (car == null)
            car = GameObject.Find("Car");

        if (camera == null)
            camera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }


    private void Init()
    {
        Verification();
        timeManager.Initialiser();

        camera.GetComponent<CameraRunner>().ReinitialiserPlayer();
        car.GetComponent<CarUserControl>().Initialiser();
        rabbit.GetComponent<PlayerController>().Initialiser();
        world.GetComponent<GenerateWorld>().Initialiser();

        //reinit Gui
        guiPause.gameObject.SetActive(false);
        guiRabbit.gameObject.SetActive(false);
        guiTuTo.gameObject.SetActive(false);
        guiGeneral.gameObject.SetActive(false);
        guiCar.transform.GetChild(0).gameObject.SetActive(false);
        guiCar.transform.GetChild(2).gameObject.SetActive(true);
        guiCar.gameObject.SetActive(false);

        game.Initialiser();
    }

    private void Start()
    {
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
