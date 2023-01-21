using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ObjectMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject playerObject;
    private Animator animationController;
    // Start is called before the first frame update
    void Start()
    {
        animationController = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerObject.transform.position);
        Debug.Log(1);
        Debug.Log(agent.remainingDistance);
        if (agent.velocity.magnitude > 5)
        {
            animationController.SetFloat("speed", 10);
        } else if(agent.velocity.magnitude > 0)
        {
            animationController.SetFloat("speed", 1);
        } else
        {
            animationController.SetFloat("speed", 0);
        }

        if (agent.remainingDistance < 0.1f)
        {
            animationController.SetFloat("speed", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
