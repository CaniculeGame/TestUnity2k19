#define DIRECT_SCENE
using UnityEngine;

public class GamePlayPause : GamePlay
{
    private TimeManager timeManager;

    public GamePlayPause(TimeManager tmManager = null)
    {
        timeManager = tmManager;
    }

    public override GAME_STATES Executer()
    {
        return GererPause();
    }


    private void ChercherTimeManager()
    {
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }

#if DIRECT_SCENE
    public void GererUnPause() {

        if (timeManager.EstEnPause() == true)
            timeManager.Pause();
     }

    public bool EstEnPause()
    {
        if (timeManager == null)
            ChercherTimeManager();
        return timeManager.EstEnPause();
    }
#endif



    public GAME_STATES GererPause()
    {
        GAME_STATES etat = GAME_STATES.GAME_STATES_PAUSE;
        if (timeManager == null)
            ChercherTimeManager();

        if (timeManager != null)
        {
            // mettre en pause
            if (timeManager.EstEnPause() == false)
                timeManager.Pause();

            //activer canvas pause
        }

#if !DIRECT_SCENE
#if UNITY_EDITOR || UNITY_EDITOR_WIN || UNITY_WEBGL

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //sortie de pause
            if (timeManager.EstEnPause() == true)
                timeManager.Pause();

            //desactive canvas pause

            etat =  GAME_STATES.GAME_STATES_PLAY;
        }
#endif
#endif
        return etat;
    }


    // action des bouttons
}
