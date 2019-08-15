using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTest;
using UnityEngine.UI;
using System.IO;
using System;

public class GamePlayQuit : GamePlay
{

    public GameObject guiGameOver;
    public GameObject gui;

    private GameObject retryButton;
    private GameObject mainMenuButton;
    private Text textScore;
    private Text textName;
    private Text textTour;
    private Text textDist;
    private Text textScoreFinal;
    private GameObject textField;


    public void Start()
    {
        retryButton     = guiGameOver.transform.GetChild(2).GetChild(0).gameObject;
        mainMenuButton  = guiGameOver.transform.GetChild(2).GetChild(1).gameObject;

        textScore   = guiGameOver.transform.GetChild(3).GetComponent<Text>();
        textName    = guiGameOver.transform.GetChild(4).GetComponent<Text>();
        textTour    = guiGameOver.transform.GetChild(6).GetChild(0).GetComponent<Text>();
        textDist    = guiGameOver.transform.GetChild(6).GetChild(1).GetComponent<Text>();
        textScoreFinal = guiGameOver.transform.GetChild(6).GetChild(2).GetComponent<Text>();
        textField   = guiGameOver.transform.GetChild(5).gameObject;


        //init langue
        textScore.text = Dictionnaires.Dictionnaire.DonnerMot("Score");
        textName.text = Dictionnaires.Dictionnaire.DonnerMot("Name");

        retryButton.GetComponentInChildren<Text>().text     = Dictionnaires.Dictionnaire.DonnerMot("Retry");
        mainMenuButton.GetComponentInChildren<Text>().text  = Dictionnaires.Dictionnaire.DonnerMot("MainMenu");
        guiGameOver.transform.GetChild(1).GetComponent<Text>().text = Dictionnaires.Dictionnaire.DonnerMot("GameOver");
    }


    public override void Initialiser()
    {
        guiGameOver.gameObject.SetActive(false);
    }

    private void Update()
    {
        Verification();
        if (game.GamePlayState != GameVar.GAME_STATES.GAME_STATES_QUIT)
            return;

        gui.transform.GetChild(0).gameObject.SetActive(false);
        gui.transform.GetChild(1).gameObject.SetActive(false);
        gui.transform.GetChild(2).gameObject.SetActive(false);
        gui.transform.GetChild(3).gameObject.SetActive(false);
        gui.transform.GetChild(4).gameObject.SetActive(false);

        if (!timeManager.EstEnPause())
            timeManager.MettrePause();

        guiGameOver.gameObject.SetActive(true);

        MajScore();
    }


    private void MajScore()
    {
        float distanceParcourue = game.DistanceParcourue;
        int tourEffectue = Mathf.RoundToInt(distanceParcourue) / game.DistanceTourDuMonde;

        textTour.text = tourEffectue.ToString() + " "+ Dictionnaires.Dictionnaire.DonnerMot("EarthTour");
        textDist.text = distanceParcourue.ToString() + " m";
        textScoreFinal.text = (distanceParcourue*(tourEffectue +1)).ToString();
    }   

    private void SaveScore()
    {
        string name = textField.GetComponentInChildren<Text>().text;

        //mettre dans fichier ressources
        string  path = Application.persistentDataPath + "/scores.txt";
        string[] data;


        float distanceParcourue = game.DistanceParcourue;
        int tourEffectue = Mathf.RoundToInt(distanceParcourue) / game.DistanceTourDuMonde;
        if (tourEffectue == 0)
            tourEffectue = 1;

        try
        {
            data = File.ReadAllLines(path);
        }
        catch (Exception e)
        {
            Debug.Log("creation fichier manquant");
            path = "Scores/scores";
            TextAsset textFile = Resources.Load<TextAsset>(path);
            Debug.Log(textFile);
                
            path = Application.persistentDataPath + "/scores.txt";
            Debug.Log(path);
            File.WriteAllText(path, textFile.ToString());
            data = File.ReadAllLines(path);
        }

        //si plus grand que le plus petit score alors...
        string[] tokens = data[0].Split(':');
        if (Int32.Parse(tokens[1]) < tourEffectue * distanceParcourue)
        {
            //rappatrier valeur sous forme de couple
            Couple[] tab =  new Couple[10];
            for(int i =0; i < 10; i++)
            {
                string[] couple = data[i].Split(':');
                tab[i] = new Couple(couple[0], float.Parse(couple[1]));
            }

            //ajouter en dernier le nouveaux score
            tab[0] = new Couple(name, (float)(tourEffectue * distanceParcourue));

            // triage simple tableau ( que 10 val amx)
            int MaxTableau = 10;

            for (int I = MaxTableau - 2; I >= 0; I--)
            {
                for (int J = 0; J <= I; J++)
                {
                    if (tab[J + 1].Valeur < tab[J].Valeur)
                    {
                        Couple t = tab[J + 1];
                        tab[J + 1] = tab[J];
                        tab[J] = t;
                    }
                }
            }

            //reforme data
            for (int i = 0; i < 10; i++)
            {
                data[i] = tab[i].Name + ":" + tab[i].Valeur;
            }
            
            //ercrire data
            File.WriteAllLines(path, data);
        }
    }

    public void Retry()
    {
        if (timeManager.EstEnPause())
            timeManager.UnPause();

        SaveScore();
        guiGameOver.gameObject.SetActive(false);
        game.GamePlayState = GameVar.GAME_STATES.GAME_STATES_START;
    }

    public void MainMenu()
    {
        if (timeManager.EstEnPause())
            timeManager.UnPause();

        SaveScore();
        guiGameOver.gameObject.SetActive(false);
        game.GamePlayState = GameVar.GAME_STATES.GAME_STATES_START;
        SceneManager.LoadScene(1);
    }
}


