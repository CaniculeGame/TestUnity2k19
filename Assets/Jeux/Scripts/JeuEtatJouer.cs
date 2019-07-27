using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTest;

public class JeuEtatJouer : Jeu
{


    private GameObject splashScreen;
    private bool demarrer = false;

    private Singleton instance;


    private GamePlay[] gamePlay;
    private GamePlay.GAME_STATES gamePlayState;

    public JeuEtatJouer()
   {
        instance = Singleton.DonnerInstance;
        demarrer = false;
        Debug.Log("instanciation JeuEtatJouer");


        gamePlay = new GamePlay[(int)GamePlay.GAME_STATES.GAME_STATES_MAX];
        gamePlay[(int)GamePlay.GAME_STATES.GAME_STATES_PLAY]    = new GamePlayPlay();
        gamePlay[(int)GamePlay.GAME_STATES.GAME_STATES_END]     = new GamePlayEnd();
        gamePlay[(int)GamePlay.GAME_STATES.GAME_STATES_PAUSE]   = new GamePlayPause();
        gamePlay[(int)GamePlay.GAME_STATES.GAME_STATES_QUIT]    = new GamePlayQuit();
        gamePlay[(int)GamePlay.GAME_STATES.GAME_STATES_START]   = new GamePlayStart();

        gamePlayState = GamePlay.GAME_STATES.GAME_STATES_PLAY;
    }

    public override STATES Executer()
    {
        STATES etatCourant = STATES.GAME;

        switch (instance.DonnerNumeroDuNiveau)
        {
            case (int)Jeu.STATES.MAIN_MENU:
                etatCourant = GoMainMenu();
                break;

             case (int)Jeu.STATES.GAME:
                gamePlayState = gamePlay[(int)gamePlayState].Executer();
                break;

            default:
                break;
        }

        return etatCourant;
    }



    public STATES GoMainMenu()
    {
        STATES etat = STATES.MAIN_MENU;

        /* recuperation des objets */
        splashScreen = GameObject.Find("ecranNoir");

        /* lancer animation type pokemon */
        if (!demarrer)
        {
            if (splashScreen != null)
            {
                /* jouer animation */
                splashScreen.SetActive(true);
                splashScreen.GetComponent<Animation>().Play();

                demarrer = true;
            }
        }


        /* on change de niveau des que l'animation est terminée*/
        if (!splashScreen.GetComponent<Animation>().isPlaying)
        {
            etat = Jeu.STATES.MAIN_MENU;
            SceneManager.LoadScene(instance.DonnerNumeroDuNiveau); /* changement de niveau */
        }

        return etat;
    }
}
