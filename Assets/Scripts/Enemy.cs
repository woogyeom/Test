using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private BaseState curState;

    // Start is called before the first frame update
    void Start()
    {
        TransitionToState(new IdleState(this));
    }

    // Update is called once per frame
    void Update()
    {
        curState.OnStateUpdate();
    }

    public void TransitionToState(BaseState state)
    {
        curState?.OnStateExit();
        curState = state;
        curState.OnStateEnter();
    }

    public void ExecuteAction()
    {
        curState.OnStateAction();
    }
}
