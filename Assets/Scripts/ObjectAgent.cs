using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectAgent : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject playerObject;
    //    public Animator animationController;
    // Start is called before the first frame update
    void Start()
    {
        // animationController = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerObject.transform.position);
        Debug.Log(1);
        Debug.Log(agent.pathEndPosition);
        /*      if (agent.velocity.magnitude < 2.0f)
              {
                  animationController.SetFloat("speed", 0);
              }
              else
              {
                  animationController.SetFloat("speed", 5);
              }*/
    }
}
