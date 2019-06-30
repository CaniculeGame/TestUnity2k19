using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTest;

public class MenuManager : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject OptionMenu;

    private Singleton instanceJeu;

    // Start is called before the first frame update
    void Start()
    {
        /*active le menu à afficher au demarrage, desactive les autres */
        MainMenu.SetActive(true);
        OptionMenu.SetActive(false);

        instanceJeu = Singleton.DonnerInstance;
    }


    public void AfficherMainMenu()
    {
        MainMenu.SetActive(true);
        OptionMenu.SetActive(false);
    }

    public void AfficherOptionMenu()
    {
        MainMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }

   public void QuitterJeu()
   {
        Debug.Log("Quitter");
        Application.Quit(0);
   }

    public void LancerJeu()
    {
        instanceJeu.DonnerNumeroDuNiveau = (int)Jeu.STATES.GAME;
    }

}
