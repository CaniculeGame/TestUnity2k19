#define DIRECT_SCENE

using System.Collections;
using System.Collections.Generic;


namespace UnityTest
{
    public class GameVar
    {
        enum State
        {
           STATE_PAUSE  = 0,
           STATE_CAR    = 1,
           STATE_ANIMAL = 2,
           STATE_MAX
        }

        private static GameVar instance = null;


        private float distanceParcourue = 0; // km
        private State gameState = State.STATE_CAR;


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
