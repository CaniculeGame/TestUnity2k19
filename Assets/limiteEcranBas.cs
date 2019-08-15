using UnityTest;
using UnityEngine;

public class limiteEcranBas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerCar" || other.tag == "PlayerAnimal")
        {
            GameVar.DonnerInstance().GamePlayState = GameVar.GAME_STATES.GAME_STATES_QUIT;
        }
    }

}
