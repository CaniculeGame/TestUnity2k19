using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTest;

public class GamePlayQuit : GamePlay
{
    private void Update()
    {
        Verification();
        if (game.GamePlayState != GameVar.GAME_STATES.GAME_STATES_QUIT)
            return;

        SceneManager.LoadScene(1);
    }
}
