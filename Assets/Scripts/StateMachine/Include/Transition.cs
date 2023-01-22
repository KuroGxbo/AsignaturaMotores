using UnityEngine;

public class Transition
{
    public State nextState;
    public Condition condition;

    public Transition(State nextState, Condition condition)
    {
        this.nextState = nextState;
        this.condition = condition;
    }

    public bool IsTriggered()
    {
        return condition.Check();
    }
}
