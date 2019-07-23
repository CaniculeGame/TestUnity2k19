using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTest;


public class Main : MonoBehaviour
{

    private Singleton instance;
    private Jeu[] jeu;

    private void Start()
    {
        instance = Singleton.DonnerInstance;

        jeu = new Jeu[(int)Jeu.STATES.TOTAL];
        jeu[(int)Jeu.STATES.GAME] = new JeuEtatJouer();
        jeu[(int)Jeu.STATES.MAIN_MENU] = new JeuEtatMainMenu();
        jeu[(int)Jeu.STATES.SPLASHSCREEN_LOGO] = new JeuEtatSplashScreen();

        
    }


    private void Update()
    {
        jeu[Jeu.DonnerEtatCourant].Executer();
    }

}
