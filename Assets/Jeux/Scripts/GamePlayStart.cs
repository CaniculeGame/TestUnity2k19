﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayStart : GamePlay
{
    public override GAME_STATES Executer()
    {
        return GAME_STATES.GAME_STATES_PLAY;
    }

}
