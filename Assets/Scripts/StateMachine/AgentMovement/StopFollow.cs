using UnityEngine;
using UnityEngine.AI;

public class StopFollow : State
{
    NavMeshAgent _npc;
    Animator _animator;

    public StopFollow(NavMeshAgent npc, Animator animator)
    {
        _npc = npc;
        _animator = animator;
    }

    public override void DoAction()
    {
        _npc.isStopped = true;
        _animator.SetBool("Dance", false);
        _animator.SetFloat("speed", 0);
    }
}
