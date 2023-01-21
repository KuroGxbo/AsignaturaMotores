using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class littlegirl_movement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject playerObject;
    public Animator animationController;
    public NavMeshPathStatus objectStatus;
    // Start is called before the first frame update
    void Start()
    {
        animationController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerObject.transform.position);
        if (agent.velocity.magnitude > 5)
        {
            animationController.SetFloat("speed", 10);
        }
        else if (agent.velocity.magnitude > 0)
        {
            animationController.SetFloat("speed", 1);
        }
        else
        {
            animationController.SetFloat("speed", 0);
        }

        if (agent.remainingDistance < 0.1f)
        {
            animationController.SetFloat("speed", 0);
        }
    }
}
