#define DIRECT_SCENE

using System.Collections;
using System.Collections.Generic;


namespace UnityTest
{
    public class GameVar
    {
        public enum State
        {
           STATE_PAUSE  = 0,
           STATE_CAR    = 1,
           STATE_ANIMAL = 2,
           STATE_MAX
        }


        public enum GAME_STATES : int
        {
            GAME_STATES_START = 0,
            GAME_STATES_PAUSE = 1,
            GAME_STATES_PLAY = 2,
            GAME_STATES_END = 3,
            GAME_STATES_QUIT = 4,
            GAME_STATES_MAX = 5
        }


        public enum PLAYER : int
        {
            PLAYER_CAR = 0,
            PLAYER_ANIMAL = 1,
        }


        private static GameVar instance = null;


        private float distanceParcourue = 0; // km
        private State gameState = State.STATE_CAR;
        private GAME_STATES gamegamePlayState;
        private PLAYER gamePlay;

        private GameVar()
        {
            /* creer valeurs à partager */
            Initialiser();
        }

        public void Initialiser()
        {
            distanceParcourue = 0;
            gamePlay = GameVar.PLAYER.PLAYER_CAR;
            gamegamePlayState = GameVar.GAME_STATES.GAME_STATES_START;
            gameState = State.STATE_CAR;
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


        public GAME_STATES GamePlayState
        {
            set { gamegamePlayState = value; }
            get { return gamegamePlayState; }
        }

        public PLAYER GamePlay
        {
            set { gamePlay = value; }
            get { return gamePlay; }
        }

    }
}
