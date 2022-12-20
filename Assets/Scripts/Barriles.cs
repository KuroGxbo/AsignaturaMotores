using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriles : MonoBehaviour
{
    public GameObject FilaBarriles;
    int playerPositionZ;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // en proceso playerPositionZ = 

        if (playerPositionZ == 100)
        {
            Instantiate(FilaBarriles, FilaBarriles.transform.position, FilaBarriles.transform.rotation);
        }
    }
}
