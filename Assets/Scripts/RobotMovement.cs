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
    private bool _shootEnable = false;
    private bool _shootingToggle = false;
    public PauseMenu menu;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
        _centre = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!menu.EstadoMenu)
        {
            dist = Vector3.Distance(player.transform.position, _centre);
            if (dist < 20.0f)
            {
                transform.LookAt(player.transform);
                if (_shootEnable && !_shootingToggle)
                {
                    StartCoroutine(Shoot());
                    _shootingToggle = true;
                }
                _shootEnable = true;
            }
            else
            {
                _shootingToggle = false;
                _shootEnable = false;
                transform.rotation = Quaternion.identity;
                _angle -= rotateSpeed * Time.deltaTime;

                var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * radius;

                transform.position = new Vector3(_centre.x + offset.x, transform.position.y, _centre.z + offset.y);
            }
        } else
        {
            _shootEnable= false;
        }
    }

    IEnumerator Shoot()
    {
        while (_shootEnable)
        {
            GameObject bulletCopy = Instantiate(bullet, bulletPosition.position, Quaternion.identity);
            bulletCopy.GetComponent<bullet>().robot = gameObject;
            bulletCopy.transform.LookAt(player.transform.position + new Vector3(0, 1.4f, 0));
            yield return new WaitForSeconds(shootingSpeed);
        }
    }
}
