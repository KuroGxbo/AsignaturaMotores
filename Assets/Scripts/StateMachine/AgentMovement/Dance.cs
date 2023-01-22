using UnityEngine;

public class Dance : State
{
    Animator _animation;

    public Dance(Animator animator)
    {
        _animation = animator;
    }

    public override void DoAction()
    {
        _animation.SetBool("Dance", true);
    }
}
