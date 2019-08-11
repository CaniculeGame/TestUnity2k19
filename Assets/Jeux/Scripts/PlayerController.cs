using UnityEngine;
using UnityEngine.UI;
using UnityTest;
using UnityStandardAssets.Vehicles.Car;

public class PlayerController : MonoBehaviour
{
    private bool premiereFois = false;
    public  Camera camera;
    public Rigidbody rigidbody;
    public GameObject ui;

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
        this.transform.position = new Vector3(270f, 1.22f, 3);
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
            float angle     = collision.collider.GetComponentInParent<CarController>().GetAngle();
            float angleRad  = Mathf.PI * (angle) / 180f; // deg to rad
            float vitesse   = collision.collider.GetComponentInParent<Rigidbody>().velocity.x * 3.6f; // m/sec to km/h
            float masse     = collision.collider.GetComponentInParent<Rigidbody>().mass; //en kg

            collision.collider.GetComponentInParent<CarUserControl>().enabled = false;
            collision.collider.GetComponentInParent<CarController>().enabled = false;

            // passage du playerCar a playerAnimal
            camera.GetComponent<CompteurVitesse>().ChangerReferentiel(this.transform);
            camera.GetComponent<CameraRunner>().SwitchPlayer();
            premiereFois = true;

            //lancement
            transform.Rotate(new Vector3(0f, 90f, 0f));

            // calcul du vecteur
            float energie = ((1f / 2f) * masse * Mathf.Pow(vitesse/3.6f, 2)) / 10000f;
            //Debug.Log("f= " + energie + " m="+masse+"  v="+vitesse );
            float cos = Mathf.Cos(angleRad);
            float sin = Mathf.Sin(angleRad);

            Vector3 vecteur = new Vector3(cos* energie, sin * energie, 3);
            rigidbody.AddForce(vecteur, ForceMode.Impulse);
        }
    }
}
