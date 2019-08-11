using UnityEngine;
using UnityTest;
using UnityStandardAssets.Vehicles.Car;

public class PlayerController : MonoBehaviour
{
    private bool premiereFois = false;
    public  Camera camera;
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Initialiser();
    }

    public void Initialiser()
    {
        premiereFois = false;
        this.transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        this.transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        this.transform.position = new Vector3(4.25f, 1.22f, 3);
        this.transform.rotation = new Quaternion(0, 90, 0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameVar.GAME_STATES.GAME_STATES_PLAY ==  GameVar.DonnerInstance().GamePlayState  && 
            GameVar.DonnerInstance().GamePlay == GameVar.PLAYER.PLAYER_ANIMAL)
        {



        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "PlayerCar" && premiereFois == false)
        {
            // desactive le control de la voiture
            collision.collider.GetComponentInParent<CarUserControl>().enabled = false;
            collision.collider.GetComponentInParent<CarController>().enabled = false;

            // passage du playerCar a playerAnimal

            camera.GetComponent<CompteurVitesse>().ChangerReferentiel(this.transform);
            camera.GetComponent<CameraRunner>().SwitchPlayer();
            premiereFois = true;

            //lancement
            transform.Rotate(new Vector3(0f, 90f, 0f));

            // calcul du vecteur
            //angle de frenage 0 et 70 
            float angle = 45f; //degre
            float vitesse = 130f / 3.6f ; // km/h -> m/s
            float masse = 1500f; //kg

            float force = 100;// NM
            float angleRad = Mathf.PI * (angle) / 180f;
            Vector3 vecteur = new Vector3(Mathf.Cos(angleRad) * force,Mathf.Sin(angleRad) * force,3);
            rigidbody.AddForce(vecteur, ForceMode.Impulse);
        }
    }
}
