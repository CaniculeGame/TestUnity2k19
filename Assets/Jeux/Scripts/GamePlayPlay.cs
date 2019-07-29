using UnityEngine;
using UnityEngine.UI;
using UnityTest;

public class GamePlayPlay : GamePlay
{
    private GameVar.PLAYER player = GameVar.PLAYER.PLAYER_CAR;
    public GameObject guiCompteur;

    private void Start()
    {
        game = GameVar.DonnerInstance();
    }

    private void Update()
    {
        Verification();
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

        Text txt = guiCompteur.transform.GetComponent<Text>();
        txt.text = distanceParcourue.ToString("0000000000000") + " m";
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
}
