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

    // Start is called before the first frame update
    void Start()
    {
        Initialisation();
    }

    public void Initialisation()
    {
        slider.value = 0.98f;
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        //recupere vitesse de la voiture
        vMax = car.GetComponent<CarController>().MaxSpeed;
        vit = (car.GetComponent<Rigidbody>().velocity.x * 3.6f);

        //normaliser pour etre entre 0 et 1
        vfinal = vit / vMax;

        //inverse la valeur pour affichage correct
        slider.value = 1 - vfinal;
    }
}
