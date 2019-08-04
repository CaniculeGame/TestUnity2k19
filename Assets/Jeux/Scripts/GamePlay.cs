using UnityEngine;
using UnityTest;

public abstract class GamePlay : MonoBehaviour
{
    protected TimeManager timeManager;
    protected GameVar game;


    public abstract void Initialiser();

    protected void ChercherTimeManager()
    {
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }


    protected void Verification()
    {

        if (game == null)
            game = GameVar.DonnerInstance();

        if (timeManager == null)
            ChercherTimeManager();
    }



}
