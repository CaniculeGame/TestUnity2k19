using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTest;

public class FinDuNuiveau : MonoBehaviour
{
    public GameObject ecranNoir;

    private void OnCollisionEnter(Collision collision)
    {
        Singleton inst = Singleton.DonnerInstance;
        inst.RetourMainMenu();
        ecranNoir.SetActive(true);
    }
}
