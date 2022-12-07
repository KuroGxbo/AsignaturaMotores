using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    private float rotateSpeed = 0.5f;
    private float radius = 5f;

    private Vector3 _centre;
    private float _angle;

    // Start is called before the first frame update
    void Start()
    {
        _centre = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        _angle += rotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * radius;

        transform.position = new Vector3(_centre.x + offset.x, transform.position.y, _centre.z + offset.y);
    }
}
