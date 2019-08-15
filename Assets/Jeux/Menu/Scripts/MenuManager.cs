using UnityEngine;
using UnityTest;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using System.IO;

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

       int lgId = PlayerPrefs.GetInt("langue");
        EventSystem.current.SetSelectedGameObject(OptionMenu.transform.GetChild(2).GetChild(lgId).gameObject);
    }

    public void AfficherCustomCarMenu()
    {
        MainMenu.SetActive(false);
        CustomCarMenu.SetActive(true);
        CustomCharMenu.SetActive(false);
        CustomAnimalsMenu.SetActive(false);
        OptionMenu.SetActive(false);
        HightScoreMenu.SetActive(false);

        int carId = PlayerPrefs.GetInt("CarId");
        EventSystem.current.SetSelectedGameObject(CustomCarMenu.transform.GetChild(2).GetChild(carId).gameObject);
    }


    public void AfficherCustomAnimalMenu()
    {
        MainMenu.SetActive(false);
        CustomCarMenu.SetActive(false);
        CustomCharMenu.SetActive(false);
        CustomAnimalsMenu.SetActive(true);
        OptionMenu.SetActive(false);
        HightScoreMenu.SetActive(false);

        int petId = PlayerPrefs.GetInt("PetId");
        EventSystem.current.SetSelectedGameObject(CustomAnimalsMenu.transform.GetChild(2).GetChild(petId).gameObject);
    }

    public void AfficherHightScorelMenu()
    {
        MainMenu.SetActive(false);
        CustomCarMenu.SetActive(false);
        CustomCharMenu.SetActive(false);
        CustomAnimalsMenu.SetActive(false);
        OptionMenu.SetActive(false);
        HightScoreMenu.SetActive(true);

        //rafraichir score
        RafraichirGuiCustomHightScore();


    }


    public void AfficherCustomCharMenu()
    {
        MainMenu.SetActive(false);
        CustomCarMenu.SetActive(false);
        CustomCharMenu.SetActive(true);
        CustomAnimalsMenu.SetActive(false);
        OptionMenu.SetActive(false);
        HightScoreMenu.SetActive(false);

        int charId = PlayerPrefs.GetInt("CharId");
        EventSystem.current.SetSelectedGameObject(CustomCharMenu.transform.GetChild(2).GetChild(charId).gameObject);
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


        //ouvrir fichier
        string path = Application.persistentDataPath + "/scores.txt";
        string[] data;
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

        //rappatrier valeur sous forme de couple
        Couple[] tab = new Couple[10];
        for (int i = 0; i < 10; i++)
        {
            string[] couple = data[i].Split(':');
            tab[i] = new Couple(couple[0], float.Parse(couple[1]));
        }

        GameObject panel = HightScoreMenu.transform.GetChild(3).GetChild(0).gameObject;
        //modifier text
        for (int i=9; i >= 0;i--)
        {
            string str = (10-i).ToString() + "  " + tab[i].Name + "  " + tab[i].Valeur.ToString();
            panel.transform.GetChild(9-i).GetComponent<Text>().text = str;
        }
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
        Debug.Log("ChoosePerso " + id);

        //changer background
    }

    public void ChoosePet(int id)
    {
        PlayerPrefs.SetInt("PetId", id);
        PlayerPrefs.Save();
        Debug.Log("ChoosePet " + id);

        //changer background
    }

    public void ChooseCar(int id)
    {
        PlayerPrefs.SetInt("CarId", id);
        PlayerPrefs.Save();
        Debug.Log("ChooseCar " + id);

        //changer background
    }

}
