using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierRotation : MonoBehaviour
{

    public GameObject rotador;
    public float playerPositionZ, rotacionBarreraZ, posicionBarreraZ, diferencia, rotationSpeed, rotacionBarrera;
    public bool rotacionHecha = false;

    // Start is called before the first frame update
    void Start()
    {
        posicionBarreraZ = gameObject.transform.position.z;
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPositionZ = GameObject.Find("Player").transform.position.z;
        rotacionBarreraZ = rotador.transform.rotation.z;
        diferencia = posicionBarreraZ - playerPositionZ;


        if (diferencia < 20 && rotacionHecha==false)
        {
            rotador.transform.Rotate(new Vector3(0, 0, 90));
            rotacionHecha = true;
        }
    }
}
