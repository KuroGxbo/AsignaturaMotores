using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    private float rotateSpeed = 0.5f;
    private float radius = 5f;
    public GameObject player;
    public GameObject bullet;
    public float speedFollow;
    public float shootingSpeed = 3;

    private Vector3 _centre;
    private float _angle;
    private float dist;
    public Transform originalRotation, bulletPosition;

    // Start is called before the first frame update
    void Start()
    {
        _centre = transform.position;
        Invoke("Shoot", shootingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        _angle -= rotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * radius;

        transform.position = new Vector3(_centre.x + offset.x, transform.position.y, _centre.z + offset.y);
    }

    void Shoot()
    {
        GameObject bulletCopy = Instantiate(bullet, bulletPosition.position, Quaternion.identity);
        bulletCopy.GetComponent<bullet>().robot = gameObject;
        bulletCopy.transform.LookAt(player.transform.position + new Vector3(0, 1.4f, 0));
        Invoke("Shoot", shootingSpeed);
    }
}
