using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;

    // Update is called once per frame
    void Update()
    {
        foreach (Transition transition in  currentState.transitions)
        {
            Debug.Log(transition);
            Debug.Log(transition.IsTriggered());
            if ( transition.IsTriggered())
            {
                currentState = transition.nextState;
            }
        }
        currentState.DoAction();
    }
}
