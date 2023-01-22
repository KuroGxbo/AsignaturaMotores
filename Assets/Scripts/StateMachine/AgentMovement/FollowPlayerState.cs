using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerState : State
{
    NavMeshAgent _agent;
    GameObject _player;
    Animator _animation;

    public FollowPlayerState(NavMeshAgent agent, GameObject player, Animator animation)
    {
        _agent = agent; 
        _player = player;
        _animation = animation;
    }

    public override void DoAction()
    {
        _agent.isStopped = false;
        _agent.SetDestination(_player.transform.position);
        _animation.SetFloat("speed", 5);
    }
}
