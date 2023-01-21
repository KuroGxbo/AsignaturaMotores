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
        if (agent.velocity.magnitude < 2.0f)
        {
            animationController.SetFloat("speed", 0);
        } else
        {
            animationController.SetFloat("speed", 5);
        }
    }
}
