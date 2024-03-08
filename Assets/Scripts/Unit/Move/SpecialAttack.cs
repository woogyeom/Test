using UnityEngine;

public class SpecialAttack : Move
{
    private Unit target;
    public SpecialAttack(Unit actor, Unit target) : base(actor)
    {
        this.target = target;
    }

    public override void ExecuteAction()
    {
        for (int i = 0; i < 2; i++)
        {
            (int damage, bool crit) = actor.CalculateDamage(target);
            target.GetDamage(damage, crit);
        }
    }

}
