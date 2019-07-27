using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTest;

public class JeuEtatSplashScreen : Jeu
{
    private float tpsAttenteMax; /* en sec*/

    public JeuEtatSplashScreen()
    {
        tpsAttenteMax = 10; /*sec*/
        Debug.Log("instanciation JeuEtatSplashScreen");
    }

    public override STATES Executer()
    {
        float tpsActu = Time.time;
        STATES etatCourant = STATES.SPLASHSCREEN_LOGO;

        /* si trop d'attente on passe a l'ecran suivant*/
        if (tpsActu > tpsAttenteMax)
            etatCourant = STATES.MAIN_MENU;

        /* si appui n'importe quel touche on passe a l'ecran suivant*/
        if (Input.anyKey)
            etatCourant = STATES.MAIN_MENU;

        if (etatCourant != STATES.SPLASHSCREEN_LOGO)
        {
            Singleton inst = Singleton.DonnerInstance;
            inst.DonnerNumeroDuNiveau = (int)STATES.MAIN_MENU; /* changement du numero du level */
            SceneManager.LoadScene(inst.DonnerNumeroDuNiveau); /* changement de niveau */
        }

        Debug.Log("Executer JeuEtatSplashScreen" + tpsActu);
        return etatCourant;
    }

}
