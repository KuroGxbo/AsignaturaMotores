using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject Player;
    private Vector3 Move;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame

    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x , Player.transform.position.y + 0.5f, Player.transform.position.z-2);
    }
}
