using UnityEngine;
using UnityTest;

public class GamePlayPlay : MonoBehaviour
{

    private GameVar game;
    public TimeManager timeManager;    //gestion dsu slow motion 

    private GameVar.PLAYER player = GameVar.PLAYER.PLAYER_CAR;



    private void Start()
    {
        game = GameVar.DonnerInstance();
    }

    private void Update()
    {
        if (game == null)
            game = GameVar.DonnerInstance();

        if (game.GamePlayState != GameVar.GAME_STATES.GAME_STATES_PLAY)
            return;

        float distanceParcourue = game.DistanceParcourue;
        if (distanceParcourue > 250 && distanceParcourue < 255)
        {
            //passage en slowmotion pour tous le monde
            if (timeManager == null)
                ChercherTimeManager();

            timeManager.DoSlowmotion();


            // changement de gameplay
        }
        else if (distanceParcourue > 255)
        {
            if (timeManager == null)
                ChercherTimeManager();

            //sortie du slowmotion
            timeManager.StopSlowMotion();


            // changement de gameplay
        }
    }

    /*
    public override GAME_STATES Executer()
    {
        if (game == null)
            game = GameVar.DonnerInstance();


        float distanceParcourue = game.DistanceParcourue;
        if (distanceParcourue > 250 && distanceParcourue < 255)
        {
            //passage en slowmotion pour tous le monde
            if (timeManager == null)
                ChercherTimeManager();

            timeManager.DoSlowmotion();


            // changement de gameplay
        }
        else if (distanceParcourue > 255)
        {
            if (timeManager == null)
                ChercherTimeManager();

            //sortie du slowmotion
            timeManager.StopSlowMotion();


            // changement de gameplay
        }

        return GAME_STATES.GAME_STATES_PLAY;
    }
    */


    private void ChercherTimeManager()
    {
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }

}
