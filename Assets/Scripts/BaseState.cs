using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected Enemy _enemy;

    protected BaseState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
    public abstract void OnStateAction();
    public abstract void OnStateExit();
}

public class IdleState : BaseState
{
    public IdleState(Enemy enemy) : base(enemy) { }

    public override void OnStateEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateUpdate()
    {
        throw new System.NotImplementedException();
    }
    public override void OnStateAction()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateExit()
    {
        throw new System.NotImplementedException();
    }
}

public class PatrolState : BaseState
{
    public PatrolState(Enemy enemy) : base(enemy) { }

    public override void OnStateEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateAction()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateExit()
    {
        throw new System.NotImplementedException();
    }
}

public class ChaseState : BaseState
{
    public ChaseState(Enemy enemy) : base(enemy) { }

    public override void OnStateEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateAction()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateExit()
    {
        throw new System.NotImplementedException();
    }
}

public class AttackState : BaseState
{
    public AttackState(Enemy enemy) : base(enemy) { }

    public override void OnStateEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateAction()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateExit()
    {
        throw new System.NotImplementedException();
    }
}

public class FleeState : BaseState
{
    public FleeState(Enemy enemy) : base(enemy) { }

    public override void OnStateEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateAction()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateExit()
    {
        throw new System.NotImplementedException();
    }
}