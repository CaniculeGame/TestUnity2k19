using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTest;

public class GamePlayStart : GamePlay 
{
    public GameObject guiPause;
    public GameObject guiGeneral;
    public GameObject guiCar;
    public GameObject guiRabbit;
    public GameObject guiTuTo;


    private void Initialiser()
    {
        Verification();

        //reinit vehicule
        game.GamePlay = GameVar.PLAYER.PLAYER_CAR;

        //reinit lapin

        //reinit camera


        //reinit score
        game.DistanceParcourue = 0;

        //reinit Gui
        guiPause.gameObject.SetActive(false);
        guiGeneral.gameObject.SetActive(false);
        guiCar.gameObject.SetActive(false);
        guiRabbit.gameObject.SetActive(false);
        guiTuTo.gameObject.SetActive(false);
    }

    private void Start()
    {

    }


    private void Update()
    {

        Verification();
        if (game.GamePlayState != GameVar.GAME_STATES.GAME_STATES_START)
            return;

        //reinit jeu
        Initialiser();

        //lance animation
        // a la fin de l animation, on change d'etat et on active les gui
        game.GamePlayState = GameVar.GAME_STATES.GAME_STATES_PLAY;
        guiGeneral.gameObject.SetActive(true);
        guiCar.gameObject.SetActive(true);
    }

}
