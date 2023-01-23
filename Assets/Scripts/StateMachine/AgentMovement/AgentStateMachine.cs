using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentStateMachine : StateMachine
{
    public GameObject player;
    public NavMeshAgent agent;
    public GameObject npcObject;
    public Animator animation;
    public PauseMenu menu;
    // Start is called before the first frame update
    void Start()
    {
        //Construct States
        FollowPlayerState follow = new FollowPlayerState(agent, player, animation);
        StopFollow stopAgent = new StopFollow(agent, animation);
        Dance agentDance = new Dance(animation);

        currentState = stopAgent;

        //Setup Conditions
        PlayerNear agentClose = new PlayerNear(player, npcObject, 30.5f, menu);
        PlayerFar agentFarAway = new PlayerFar(player, npcObject, 30.5f, menu);
        PlayerDanceCondition danceforSomeTime = new PlayerDanceCondition();

        //Transition
        Transition stopToFollow = new Transition(follow, agentFarAway);
        Transition followToStop = new Transition(agentDance, agentClose);
        Transition DanceToStop = new Transition(stopAgent, danceforSomeTime);

        stopAgent.transitions.Add(stopToFollow);
        follow.transitions.Add(followToStop);
        agentDance.transitions.Add(DanceToStop);
    }
}
