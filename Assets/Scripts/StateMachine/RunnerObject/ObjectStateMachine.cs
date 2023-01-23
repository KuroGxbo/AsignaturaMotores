using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectStateMachine : StateMachine
{
    public GameObject player;
    public GameObject npc;
    public NavMeshAgent npc_agent;
    public Animator animation;
    public PauseMenu menu;
    // Start is called before the first frame update
    void Start()
    {
        //States
        FollowRunner follow = new FollowRunner(player, npc_agent, animation);
        StopRunnerState stopRun = new StopRunnerState(npc_agent, animation);

        currentState = stopRun;
        //Condition
        FarAwayPlayerCondition farAway = new FarAwayPlayerCondition(player, npc,1.7f, menu);
        NearToPlayerCondition near = new NearToPlayerCondition(player, npc, 1.7f, menu);

        //Transition
        Transition stopToFollow = new Transition(follow, farAway);
        Transition followToStop = new Transition(stopRun, near);

        follow.transitions.Add(followToStop);
        stopRun.transitions.Add(stopToFollow);
    }
}
