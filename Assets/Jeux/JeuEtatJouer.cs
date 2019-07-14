using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTest;

public class JeuEtatJouer : Jeu
{
    private GameObject splashScreen;
    private bool demarrer = false;

    private Singleton instance;

    public JeuEtatJouer()
   {
        instance = Singleton.DonnerInstance;
        demarrer = false;
        Debug.Log("instanciation JeuEtatJouer");
   }

    public override void Executer()
    {
        if (instance.DonnerNumeroDuNiveau != (int)Jeu.STATES.GAME)
        {
            Debug.Log("fin jeu");
            /* recuperation des objets */
            splashScreen = GameObject.Find("ecranNoir");

            /* lancer animation type pokemon */
            if (!demarrer)
            {
                if (splashScreen != null)
                {
                    /* jouer animation */
                    splashScreen.SetActive(true);
                    splashScreen.GetComponent<Animation>().Play();

                    demarrer = true;
                }
            }


            /* on change de niveau des que l'animation est terminée*/
            if (!splashScreen.GetComponent<Animation>().isPlaying)
            {
                etatCourant = Jeu.STATES.MAIN_MENU;
                SceneManager.LoadScene(instance.DonnerNumeroDuNiveau); /* changement de niveau */
            }
        }

    }
}
