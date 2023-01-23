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
        PlayerMovementStateMachine player = collision.gameObject.GetComponent<PlayerMovementStateMachine>();
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
