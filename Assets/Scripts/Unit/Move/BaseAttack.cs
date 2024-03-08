using UnityEngine;

public class BaseAttack : Move
{
    private Unit target;
    public BaseAttack(Unit actor, Unit target) : base(actor)
    {
        this.target = target;
    }

    public override void ExecuteAction()
    {
        (int damage, bool crit) = actor.CalculateDamage(target);
        target.GetDamage(damage, crit);
    }

}
