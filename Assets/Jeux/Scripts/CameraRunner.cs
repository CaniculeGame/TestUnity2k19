using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTest;

public class CameraRunner : MonoBehaviour
{
    public enum PLAYER : int
    {
        PLAYER_CAR = 0,
        PLAYER_ANIMAL = 1
    }

    public PLAYER currentPlayer = PLAYER.PLAYER_CAR;
    public Transform playerCar;
    public Transform playerRabbit;
    public Transform road;

    private GameVar game;

    private PLAYER CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }

    private void Start()
    {
        game = GameVar.DonnerInstance();
        ReinitialiserPlayer();
    }

    void Update()
    {

        if(game == null)
            game = GameVar.DonnerInstance();

        if (currentPlayer == PLAYER.PLAYER_CAR)
        {
            transform.position = new Vector3(playerCar.position.x + 6, playerCar.position.y + 1.5f, -10);
            road.position = new Vector3(playerCar.position.x, -0.7f, 3);
        }
        else if(currentPlayer == PLAYER.PLAYER_ANIMAL)
        {
            transform.position = new Vector3(playerRabbit.position.x + 1, playerRabbit.position.y + 2.5f, -10);
            road.position = new Vector3(playerRabbit.position.x, -0.7f, 3);
        }

    }


    public void ReinitialiserPlayer()
    {
        currentPlayer = PLAYER.PLAYER_CAR;
    }


    public void SwitchPlayer()
    {
        if (currentPlayer == PLAYER.PLAYER_CAR)
            currentPlayer = PLAYER.PLAYER_ANIMAL;
        else
            currentPlayer = PLAYER.PLAYER_CAR;
    }

}
