using UnityEngine;
using UnityEngine.AI;

public class StopRunnerState : State
{
    NavMeshAgent _npc;
    Animator _animation;
    
    public StopRunnerState(NavMeshAgent npc, Animator animation)
    {
        _npc = npc;
        _animation = animation;
    }

    public override void DoAction()
    {
        _animation.SetFloat("speed", 0);
        _npc.isStopped = true;
    }
}
