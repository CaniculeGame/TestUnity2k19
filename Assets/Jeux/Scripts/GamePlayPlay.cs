using UnityEngine;
using UnityEngine.UI;
using UnityTest;

public class GamePlayPlay : GamePlay
{
    private int distanceTourMonde = 40010000; //m
    private GameVar.PLAYER player = GameVar.PLAYER.PLAYER_CAR;
    public GameObject guiCompteur;
    public GameObject guiMain;

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
        int tourEffectue = Mathf.RoundToInt(distanceParcourue)/ distanceTourMonde;
        if (distanceParcourue > 250 && distanceParcourue < 255)
        {

            timeManager.DoSlowmotion();


            // changement de gameplay
        }
        else if (distanceParcourue > 255)
        {
            //sortie du slowmotion
            timeManager.StopSlowMotion();


            // changement de gameplay
        }

        Text txt = guiCompteur.transform.GetComponent<Text>();
        txt.text = distanceParcourue.ToString("0000000000000") + " m";
        txt.text += "\n" + tourEffectue.ToString("000") +" "+Dictionnaires.Dictionnaire.DonnerMot("EarthTour");

        switch (game.GamePlay)
        {
            case GameVar.PLAYER.PLAYER_ANIMAL:
                guiMain.transform.GetChild(2).gameObject.SetActive(false);
                guiMain.transform.GetChild(3).gameObject.SetActive(true);
                break;

            case GameVar.PLAYER.PLAYER_CAR:
                guiMain.transform.GetChild(2).gameObject.SetActive(true);
                guiMain.transform.GetChild(3).gameObject.SetActive(false);
                break;
        }
    }

    public override void Initialiser()
    {
        throw new System.NotImplementedException();
    }
}
