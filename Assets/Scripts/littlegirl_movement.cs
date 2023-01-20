using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class littlegirl_movement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerObject.transform.position);
    }
}
