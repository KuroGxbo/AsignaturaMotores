using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public GameObject robot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;    
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("shoot");
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null )
        {
            player.TakeDamage(5f);
            Debug.Log("shoot");
        }
        if(collision.gameObject != robot)
        {
            Destroy(gameObject);
        }
        
    }
}
