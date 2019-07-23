using System.Collections;
using System.Collections.Generic;


namespace UnityTest
{
    public class GameVar
    {
        private static GameVar instance = null;


        private float distanceParcourue = 0; // km


        private GameVar()
        {
            /* creer valeurs à partager */
            Initialiser();
        }

        private void Initialiser()
        {
            distanceParcourue = 0;
        }


        public static GameVar DonnerInstance()
        {
            if (instance == null)
                instance = new GameVar();

            return instance;
        }


        public float DistanceParcourue
        {
            set { distanceParcourue = value; }
            get { return distanceParcourue; }
        }


    }
}
