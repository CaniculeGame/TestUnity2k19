using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTest;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionMenu;
    public GameObject CustomCarMenu;
    public GameObject CustomCharMenu;
    public GameObject CustomAnimalsMenu;

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

        instanceJeu = Singleton.DonnerInstance;
    }


    public void AfficherMainMenu()
    {
        MainMenu.SetActive(true);
        OptionMenu.SetActive(false);
        CustomCarMenu.SetActive(false);
        CustomCharMenu.SetActive(false);
        CustomAnimalsMenu.SetActive(false);
    }

    public void AfficherOptionMenu()
    {
        MainMenu.SetActive(false);
        CustomCarMenu.SetActive(false);
        CustomCharMenu.SetActive(false);
        CustomAnimalsMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }

    public void AfficherCustomCarMenu()
    {
        MainMenu.SetActive(false);
        CustomCarMenu.SetActive(true);
        CustomCharMenu.SetActive(false);
        CustomAnimalsMenu.SetActive(false);
        OptionMenu.SetActive(false);
    }


    public void AfficherCustomAnimalMenu()
    {
        MainMenu.SetActive(false);
        CustomCarMenu.SetActive(false);
        CustomCharMenu.SetActive(false);
        CustomAnimalsMenu.SetActive(true);
        OptionMenu.SetActive(false);
    }


    public void AfficherCustomCharMenu()
    {
        MainMenu.SetActive(false);
        CustomCarMenu.SetActive(false);
        CustomCharMenu.SetActive(true);
        CustomAnimalsMenu.SetActive(false);
        OptionMenu.SetActive(false);
    }

    public void QuitterJeu()
   {
        Debug.Log("Quitter");
        Application.Quit(0);
   }

    public void LancerJeu()
    {
        Debug.Log("test");
        instanceJeu.DonnerNumeroDuNiveau = (int)Jeu.STATES.GAME;
        GameVar.DonnerInstance().GamePlayState = GameVar.GAME_STATES.GAME_STATES_START;
        OptionMenu.SetActive(false);
        CustomCarMenu.SetActive(false);
        CustomCharMenu.SetActive(false);
        CustomAnimalsMenu.SetActive(false);
    }

}
