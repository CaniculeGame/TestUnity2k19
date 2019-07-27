using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GamePlay : MonoBehaviour
{
    public enum GAME_STATES : int
    {
        GAME_STATES_START = 0,
        GAME_STATES_PAUSE = 1,
        GAME_STATES_PLAY  = 2,
        GAME_STATES_END   = 3,
        GAME_STATES_QUIT  = 4,
        GAME_STATES_MAX   = 5  
    }

    public abstract GAME_STATES Executer();

}
