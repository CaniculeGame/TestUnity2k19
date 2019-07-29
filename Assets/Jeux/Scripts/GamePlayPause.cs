using UnityEngine;
using UnityTest;

public class GamePlayPause : GamePlay
{

    public GameObject GuiPause;
    public GameObject GuiGameplayCar;
    public GameObject GuiGameplayRabbit;

    private void Start()
    {
        game = GameVar.DonnerInstance();
        ChercherTimeManager();
    }

    public GamePlayPause(TimeManager tmManager = null)
    {
        timeManager = tmManager;
    }




    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (timeManager != null)
            {
                // mettre en pause
                timeManager.Pause();

                if (timeManager.EstEnPause() == true)
                {
                    //changement etat
                    game.GamePlayState = GameVar.GAME_STATES.GAME_STATES_PAUSE;
                    //activer canvas pause
                    GuiPause.gameObject.SetActive(true);
                    GuiGameplayCar.gameObject.SetActive(false);
                    GuiGameplayRabbit.gameObject.SetActive(false);
                }
                else
                {
                    //changement etat
                    game.GamePlayState = GameVar.GAME_STATES.GAME_STATES_PLAY;
                    //desactive canvas pause
                    if (game.GamePlay == GameVar.PLAYER.PLAYER_ANIMAL)
                    {
                        GuiGameplayCar.gameObject.SetActive(false);
                        GuiGameplayRabbit.gameObject.SetActive(true);
                    }
                    else if (game.GamePlay == GameVar.PLAYER.PLAYER_CAR)
                    {
                        GuiGameplayCar.gameObject.SetActive(true);
                        GuiGameplayRabbit.gameObject.SetActive(false);
                    }
                }
            }   
        }
    }



    // action des bouttons
    public void PauseButton()
    {
        Debug.Log("PauseButton");
        Verification();
        game.GamePlayState = GameVar.GAME_STATES.GAME_STATES_PAUSE;


        if (timeManager != null)
        {
            // mettre en pause
            if (timeManager.EstEnPause() == false)
            {
                timeManager.Pause();

                //activer canvas pause
                GuiPause.gameObject.SetActive(true);
                GuiGameplayCar.gameObject.SetActive(false);
                GuiGameplayRabbit.gameObject.SetActive(false);
            }
        }
    }

    public void ResumeButton()
    {
        Debug.Log("ResumeButton");
        Verification();
        game.GamePlayState = GameVar.GAME_STATES.GAME_STATES_PLAY;

        if (timeManager != null)
        {
            // mettre en pause
            if (timeManager.EstEnPause() == true)
            {
                timeManager.Pause();

                //desactiver canvas pause
                GuiPause.gameObject.SetActive(false);
                //activer canvas jeu
                if (game.GamePlay == GameVar.PLAYER.PLAYER_ANIMAL)
                {
                    GuiGameplayCar.gameObject.SetActive(false);
                    GuiGameplayRabbit.gameObject.SetActive(true);
                }
                else if(game.GamePlay == GameVar.PLAYER.PLAYER_CAR)
                {
                    GuiGameplayCar.gameObject.SetActive(true);
                    GuiGameplayRabbit.gameObject.SetActive(false);
                }
            }
        }
    }

    public void RetryButton()
    {
        Debug.Log("RetryButton");
        Verification();
        if (timeManager.EstEnPause() == true)
            timeManager.Pause();

        game.GamePlayState = GameVar.GAME_STATES.GAME_STATES_START;
    }


    public void TutoButton()
    {
        Verification();
        Debug.Log("TutoButton");
    }

    public void SoundButton()
    {
        Verification();
        Debug.Log("SoundButton");
    }

    public void EffectButton()
    {
        Verification();
        Debug.Log("EffectButton");
    }


    public void MainMenuButton()
    {
        Debug.Log("MainMenuButton");
        Verification();
        game.GamePlayState = GameVar.GAME_STATES.GAME_STATES_QUIT;
        GuiPause.gameObject.SetActive(false);
    }


}
