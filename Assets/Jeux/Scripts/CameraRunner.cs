using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTest;

public class CameraRunner : MonoBehaviour
{

    public GameVar.PLAYER currentPlayer = GameVar.PLAYER.PLAYER_CAR;
    public Transform playerCar;
    public Transform playerRabbit;
    public Transform road;

    private GameVar game;

    private GameVar.PLAYER CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }

    private void Start()
    {
        game = GameVar.DonnerInstance();
        ReinitialiserPlayer();
    }

    void Update()
    {

        if(game == null)
            game = GameVar.DonnerInstance();

        if (currentPlayer == GameVar.PLAYER.PLAYER_CAR)
        {
            transform.position = new Vector3(playerCar.position.x + 6, 0.5f, -10);
            road.position = new Vector3(playerCar.position.x, -0.9f, 3);
        }
        else if(currentPlayer == GameVar.PLAYER.PLAYER_ANIMAL)
        {
            transform.position = new Vector3(playerRabbit.position.x + 1, playerRabbit.position.y + 2.5f, -10);
            road.position = new Vector3(playerRabbit.position.x, -0.7f, 3);
        }

    }


    public void ReinitialiserPlayer()
    {
        currentPlayer = GameVar.PLAYER.PLAYER_CAR;
        this.transform.position = new Vector3(0, 5, 0);
    }


    public void SwitchPlayer()
    {
        if (currentPlayer == GameVar.PLAYER.PLAYER_CAR)
            currentPlayer = GameVar.PLAYER.PLAYER_ANIMAL;
        else
            currentPlayer = GameVar.PLAYER.PLAYER_CAR;

        game.GamePlay = currentPlayer;
    }

}
