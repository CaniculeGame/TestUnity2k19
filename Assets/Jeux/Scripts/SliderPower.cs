using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;


public class SliderPower : MonoBehaviour
{
    public Slider slider;
    public GameObject car;

    public float vfinal = 0;
    public float vMax = 0;
    public float vit = 0;

    private CarController ctrl;
    private Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        Initialisation();
    }

    public void Initialisation()
    {
        slider.value = 0.98f;
        ctrl = car.GetComponent<CarController>();
        rig = car.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //recupere vitesse de la voiture
        vMax = ctrl.MaxSpeed;
        vit = (rig.velocity.x * 3.6f);

        //normaliser pour etre entre 0 et 1
        vfinal = vit / vMax;

        //inverse la valeur pour affichage correct
        slider.value = 1 - vfinal;
    }
}
