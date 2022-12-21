using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriles : MonoBehaviour
{
    public GameObject filaBarriles;
    public float posicionZ;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        posicionZ = filaBarriles.transform.position.z;

        if (posicionZ < 125)
        {
            Destroy(gameObject);
        }
        
    }
}
