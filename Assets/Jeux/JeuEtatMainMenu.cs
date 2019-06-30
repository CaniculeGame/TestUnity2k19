using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTest;

public class JeuEtatMainMenu : Jeu
{
    private Singleton instance;

    public JeuEtatMainMenu()
    {
        instance = Singleton.DonnerInstance;
        Debug.Log("instanciation JeuEtatMainMenu");
    }

    public override void Executer()
    {
        Debug.Log("Executer JeuEtatMainMenu");
        if (instance.DonnerNumeroDuNiveau == (int)Jeu.STATES.GAME)
        {
            etatCourant = Jeu.STATES.GAME;
            SceneManager.LoadScene(instance.DonnerNumeroDuNiveau); /* changement de niveau */
        }
    }
}
