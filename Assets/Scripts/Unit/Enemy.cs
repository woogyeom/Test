using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    GameManager gameManager;
    private BaseState curState;

    void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.AddEnemy(this);

        UnitStart();

        TransitionToState(new IdleState(this));
    }

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
