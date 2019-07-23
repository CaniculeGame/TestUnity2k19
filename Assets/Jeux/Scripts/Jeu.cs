using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Jeu : MonoBehaviour
{
    public enum STATES : int
    {
        SPLASHSCREEN_LOGO = 0,
        MAIN_MENU         = 1,
        GAME              = 2,
        TOTAL             = 3
    }



    protected static STATES etatCourant;


    public Jeu()
    {
        etatCourant = STATES.SPLASHSCREEN_LOGO;
    }

    public abstract void Executer();
    public static int DonnerEtatCourant { get { return (int)etatCourant; } }

}
