using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ringAnimation : MonoBehaviour
{
    private float rotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation += 10;
        if(rotation > 360) rotation = 0;
        transform.eulerAngles = new Vector3(0, rotation, 0);

    }
}
