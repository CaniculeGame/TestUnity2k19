using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunner : MonoBehaviour
{

    public Transform player;
    public Transform road;

    void Update()
    {
       transform.position = new Vector3(player.position.x + 6, player.position.y + 2,-10);

       road.position = new Vector3(player.position.x, -0.7f, 3);
    }
}
