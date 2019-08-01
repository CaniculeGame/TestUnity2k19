using UnityEngine;
using UnityTest;
using UnityEngine.UI;
using System;

public class GamePlayPause : GamePlay
{

    public GameObject GuiPause;
    public GameObject GuiGameplayCar;
    public GameObject GuiGameplayRabbit;

    private void Start()
    {
        game = GameVar.DonnerInstance();
        ChercherTimeManager();

        /* maj gui text */
        Dictionnaires dico = Dictionnaires.Dictionnaire;
        Transform objIntermediaire = GuiPause.transform.GetChild(0);//BG
        objIntermediaire.GetChild(0).GetComponent<Text>().text = dico.DonnerMot("Pause");
        objIntermediaire = objIntermediaire.GetChild(1); // BG BUTTON
        objIntermediaire.GetChild(0).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("Resume");
        objIntermediaire.GetChild(1).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("Retry");
        objIntermediaire.GetChild(5).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("MainMenu");


        bool activated = true;
        activated = Convert.ToBoolean(PlayerPrefs.GetInt("tuto"));
        if (activated)
            objIntermediaire.GetChild(2).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("Tuto") + ":" + dico.DonnerMot("On");
        else
            objIntermediaire.GetChild(2).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("Tuto") + ":" + dico.DonnerMot("Off");

        activated = Convert.ToBoolean(PlayerPrefs.GetInt("sound"));
        if (activated)
            objIntermediaire.GetChild(3).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("Sound") + ":" + dico.DonnerMot("On");
        else
            objIntermediaire.GetChild(3).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("Sound") + ":" + dico.DonnerMot("Off");

        activated = Convert.ToBoolean(PlayerPrefs.GetInt("effect"));
        if (activated)
            objIntermediaire.GetChild(4).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("Effect") + ":" + dico.DonnerMot("On");
        else
            objIntermediaire.GetChild(4).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("Effect") + ":" + dico.DonnerMot("Off");

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


    public void TutoButton(Transform obj)
    {
        Verification();
        Debug.Log("TutoButton");

        bool activated = true;

        if (PlayerPrefs.HasKey("tuto"))
            activated = Convert.ToBoolean(PlayerPrefs.GetInt("tuto"));


        /* switch*/
        activated = !activated;
        PlayerPrefs.SetInt("tuto", Convert.ToInt32(activated));
        PlayerPrefs.Save();


        /* maj gui */
        if (activated)
            obj.GetComponentInChildren<Text>().text =
                Dictionnaires.Dictionnaire.DonnerMot("Tuto") + ":" + Dictionnaires.Dictionnaire.DonnerMot("On");
        else
            obj.GetComponentInChildren<Text>().text
                = Dictionnaires.Dictionnaire.DonnerMot("Tuto") + ":" + Dictionnaires.Dictionnaire.DonnerMot("Off");
    }

    public void SoundButton(Transform obj)
    {
        Verification();
        Debug.Log("SoundButton");

        bool activated = true;

        if (PlayerPrefs.HasKey("sound"))
            activated = Convert.ToBoolean(PlayerPrefs.GetInt("sound"));

        /* switch*/
        activated = !activated;
        PlayerPrefs.SetInt("sound", Convert.ToInt32(activated));
        PlayerPrefs.Save();

        /* maj gui */
        if (activated)
            obj.GetComponentInChildren<Text>().text =
                Dictionnaires.Dictionnaire.DonnerMot("Sound") + ":" + Dictionnaires.Dictionnaire.DonnerMot("On");
        else
            obj.GetComponentInChildren<Text>().text
                = Dictionnaires.Dictionnaire.DonnerMot("Sound") + ":" + Dictionnaires.Dictionnaire.DonnerMot("Off");
    }

    public void EffectButton(Transform obj)
    {
        Verification();
        Debug.Log("EffectButton");

        bool activated = true;

        if (PlayerPrefs.HasKey("effect"))
            activated = Convert.ToBoolean(PlayerPrefs.GetInt("effect"));

        /* switch*/
        activated = !activated;
        PlayerPrefs.SetInt("effect", Convert.ToInt32(activated));
        PlayerPrefs.Save();


        /* maj gui */
        if (activated)
            obj.GetComponentInChildren<Text>().text =
                Dictionnaires.Dictionnaire.DonnerMot("Effect") + ":" + Dictionnaires.Dictionnaire.DonnerMot("On");
        else
            obj.GetComponentInChildren<Text>().text
                = Dictionnaires.Dictionnaire.DonnerMot("Effect") + ":" + Dictionnaires.Dictionnaire.DonnerMot("Off");
    }


    public void MainMenuButton()
    {
        Debug.Log("MainMenuButton");
        Verification();
        game.GamePlayState = GameVar.GAME_STATES.GAME_STATES_QUIT;
        GuiPause.gameObject.SetActive(false);
    }


}
