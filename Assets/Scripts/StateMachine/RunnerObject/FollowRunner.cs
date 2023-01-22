using UnityEngine;
using UnityEngine.AI;

public class FollowRunner : State
{
    GameObject _player;
    NavMeshAgent _npc;
    Animator _npc_animation;

    public FollowRunner(GameObject player, NavMeshAgent npc, Animator npc_animation)
    {
        _player = player;
        _npc = npc;
        _npc_animation = npc_animation;
    }

    public override void DoAction()
    {
        _npc.isStopped = false;
        _npc_animation.SetFloat("speed", 10);
        _npc.SetDestination(_player.transform.position);
    }
}
