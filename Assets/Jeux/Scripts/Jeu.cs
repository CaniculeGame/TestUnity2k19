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
        TOTAL             
    }

    public abstract STATES Executer();


}
