using UnityEngine;
using UnityTest;
using UnityEngine.UI;
using System;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionMenu;
    public GameObject CustomCarMenu;
    public GameObject CustomCharMenu;
    public GameObject CustomAnimalsMenu;
    public GameObject HightScoreMenu;

    private Singleton instanceJeu;

    // Start is called before the first frame update
    void Start()
    {
        /*active le menu à afficher au demarrage, desactive les autres */
        MainMenu.SetActive(true);
        OptionMenu.SetActive(false);
        CustomCarMenu.SetActive(false);
        CustomCharMenu.SetActive(false);
        CustomAnimalsMenu.SetActive(false);
        HightScoreMenu.SetActive(false);

        instanceJeu = Singleton.DonnerInstance;
        RafraichirLangue();
    }

    public void RafraichirLangue()
    {
        RafraichirGUI();
    }


    public void AfficherMainMenu()
    {
        MainMenu.SetActive(true);
        OptionMenu.SetActive(false);
        CustomCarMenu.SetActive(false);
        CustomCharMenu.SetActive(false);
        CustomAnimalsMenu.SetActive(false);
        HightScoreMenu.SetActive(false);
    }

    public void AfficherOptionMenu()
    {
        MainMenu.SetActive(false);
        CustomCarMenu.SetActive(false);
        CustomCharMenu.SetActive(false);
        CustomAnimalsMenu.SetActive(false);
        OptionMenu.SetActive(true);
        HightScoreMenu.SetActive(false);
    }

    public void AfficherCustomCarMenu()
    {
        MainMenu.SetActive(false);
        CustomCarMenu.SetActive(true);
        CustomCharMenu.SetActive(false);
        CustomAnimalsMenu.SetActive(false);
        OptionMenu.SetActive(false);
        HightScoreMenu.SetActive(false);
    }


    public void AfficherCustomAnimalMenu()
    {
        MainMenu.SetActive(false);
        CustomCarMenu.SetActive(false);
        CustomCharMenu.SetActive(false);
        CustomAnimalsMenu.SetActive(true);
        OptionMenu.SetActive(false);
        HightScoreMenu.SetActive(false);
    }

    public void AfficherHightScorelMenu()
    {
        MainMenu.SetActive(false);
        CustomCarMenu.SetActive(false);
        CustomCharMenu.SetActive(false);
        CustomAnimalsMenu.SetActive(false);
        OptionMenu.SetActive(false);
        HightScoreMenu.SetActive(true);
    }


    public void AfficherCustomCharMenu()
    {
        MainMenu.SetActive(false);
        CustomCarMenu.SetActive(false);
        CustomCharMenu.SetActive(true);
        CustomAnimalsMenu.SetActive(false);
        OptionMenu.SetActive(false);
        HightScoreMenu.SetActive(false);
    }

    public void ChangerLangue(int langue)
    {
        if ((Dictionnaires.LANGUES)langue == Dictionnaires.Dictionnaire.DonnerLangue)
            return;

        Dictionnaires.Dictionnaire.ChangerLangue((Dictionnaires.LANGUES)langue);
        RafraichirGUI();
    }

    private void RafraichirGUI()
    {
        RafraichirGuiMainMenu();
        RafraichirGuiOption();
        RafraichirGuiCustomCar();
        RafraichirGuiCustomAnimal();
        RafraichirGuiCustomChar();
        RafraichirGuiCustomHightScore();
    }

    private void RafraichirGuiOption()
    {
        bool activated = true;

        // le dico avec la bonne langue
        Dictionnaires dico = Dictionnaires.Dictionnaire;

        //changer langue de toutes les interfaces
        if (PlayerPrefs.HasKey("sound"))
            activated = Convert.ToBoolean(PlayerPrefs.GetInt("sound"));
        else
            PlayerPrefs.SetInt("sound", Convert.ToInt32(activated));


        if (activated)
            OptionMenu.transform.GetChild(3).GetChild(0).GetComponentInChildren<Text>().text = dico.DonnerMot("Sound") + ":" + dico.DonnerMot("On");
        else
            OptionMenu.transform.GetChild(3).GetChild(0).GetComponentInChildren<Text>().text = dico.DonnerMot("Sound") + ":" + dico.DonnerMot("Off");


        if (PlayerPrefs.HasKey("effect"))
            activated = Convert.ToBoolean(PlayerPrefs.GetInt("effect"));
        else
            PlayerPrefs.SetInt("effect", Convert.ToInt32(activated));

        if (activated)
            OptionMenu.transform.GetChild(3).GetChild(1).GetComponentInChildren<Text>().text = dico.DonnerMot("Effect") + ":" + dico.DonnerMot("On");
        else
            OptionMenu.transform.GetChild(3).GetChild(1).GetComponentInChildren<Text>().text = dico.DonnerMot("Effect") + ":" + dico.DonnerMot("Off");


        if (PlayerPrefs.HasKey("tuto"))
            activated = Convert.ToBoolean(PlayerPrefs.GetInt("tuto"));
        else
            PlayerPrefs.SetInt("tuto", Convert.ToInt32(activated));

        if (activated)
            OptionMenu.transform.GetChild(3).GetChild(2).GetComponentInChildren<Text>().text = dico.DonnerMot("Tuto") + ":" + dico.DonnerMot("On");
        else
            OptionMenu.transform.GetChild(3).GetChild(2).GetComponentInChildren<Text>().text = dico.DonnerMot("Tuto") + ":" + dico.DonnerMot("Off");

        OptionMenu.transform.GetChild(3).GetChild(3).GetComponentInChildren<Text>().text = dico.DonnerMot("Quit");
        OptionMenu.transform.GetChild(0).GetComponentInChildren<Text>().text = dico.DonnerMot("Options");


        PlayerPrefs.Save();

    }

    private void RafraichirGuiMainMenu()
    {
        // le dico avec la bonne langue
        Dictionnaires dico = Dictionnaires.Dictionnaire;

        MainMenu.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("Options");
        MainMenu.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("CustomPerso");
        MainMenu.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("CustomAnimal");
        MainMenu.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("CustomCar");
        MainMenu.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("Play");
        MainMenu.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("HightScore");
        MainMenu.transform.GetChild(6).GetChild(0).GetComponent<Text>().text = dico.DonnerMot("Quit");
    }

    private void RafraichirGuiCustomCar()
    {
        // le dico avec la bonne langue
        Dictionnaires dico = Dictionnaires.Dictionnaire;

        CustomCarMenu.transform.GetChild(0).GetComponent<Text>().text = dico.DonnerMot("ChooseCar");
    }

    private void RafraichirGuiCustomAnimal()
    {
        // le dico avec la bonne langue
        Dictionnaires dico = Dictionnaires.Dictionnaire;

        CustomAnimalsMenu.transform.GetChild(0).GetComponent<Text>().text = dico.DonnerMot("ChoosePet");
    }


    private void RafraichirGuiCustomChar()
    {
        // le dico avec la bonne langue
        Dictionnaires dico = Dictionnaires.Dictionnaire;

        CustomCharMenu.transform.GetChild(0).GetComponent<Text>().text = dico.DonnerMot("ChooseChar");
    }


    private void RafraichirGuiCustomHightScore()
    {
        // le dico avec la bonne langue
        Dictionnaires dico = Dictionnaires.Dictionnaire;

        HightScoreMenu.transform.GetChild(0).GetComponent<Text>().text = dico.DonnerMot("HightScore");
    }


    public void QuitterJeu()
   {
        Application.Quit(0);
   }

    public void LancerJeu()
    {
        instanceJeu.DonnerNumeroDuNiveau = (int)Jeu.STATES.GAME;
        GameVar.DonnerInstance().GamePlayState = GameVar.GAME_STATES.GAME_STATES_START;
        OptionMenu.SetActive(false);
        CustomCarMenu.SetActive(false);
        CustomCharMenu.SetActive(false);
        CustomAnimalsMenu.SetActive(false);
        HightScoreMenu.SetActive(false);
    }


    public void SwitchSound(Transform obj)
    {
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

    public void SwitchEffect(Transform obj)
    {
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

    public void SwitchTuto(Transform obj)
    {
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


    public void ChoosePerso(int id)
    {
        PlayerPrefs.SetInt("PersoId",id);
        PlayerPrefs.Save();
    }

    public void ChoosePet(int id)
    {
        PlayerPrefs.SetInt("PetId", id);
        PlayerPrefs.Save();
    }

    public void ChooseCar(int id)
    {
        PlayerPrefs.SetInt("CarId", id);
        PlayerPrefs.Save();
    }

}
