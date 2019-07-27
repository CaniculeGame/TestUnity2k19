#define DIRECT_SCENE

using UnityEngine;
using UnityTest;

public class GamePlayPlay : GamePlay
{
    enum PLAYER : int
    {
        PLAYER_CAR = 0,
        PLAYER_ANIMAL = 1,
    }


    private GameVar game;
    public TimeManager timeManager;    //gestion dsu slow motion 

    private PLAYER player = PLAYER.PLAYER_CAR;


    /* uniquement pour test dans unity editor. En mode normal, execute est appelé par l'update d'une autre class */
#if UNITY_EDITOR
#if DIRECT_SCENE
    private void Start()
    {
        game = GameVar.DonnerInstance();
    }


    private void Update()
    {
       Executer();
    }
#endif
#endif


    public GamePlayPlay()
    {
        game = GameVar.DonnerInstance();
    }

    public override GAME_STATES Executer()
    {
        if (game == null)
            game = GameVar.DonnerInstance();



#if DIRECT_SCENE
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(!this.GetComponent<GamePlayPause>().EstEnPause())
                this.GetComponent<GamePlayPause>().GererPause();
            else
                this.GetComponent<GamePlayPause>().GererUnPause();
            return GAME_STATES.GAME_STATES_PAUSE;
        }
#endif


#if UNITY_EDITOR || UNITY_EDITOR_WIN || UNITY_WEBGL
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            return GAME_STATES.GAME_STATES_PAUSE; 
        }
#endif

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






    private void ChercherTimeManager()
    {
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }

}
