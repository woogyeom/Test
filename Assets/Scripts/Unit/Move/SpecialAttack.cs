using UnityEngine;

public class SpecialAttack : Move
{
    public SpecialAttack(Unit actor, Unit target) : base(actor) { this.target = target; }

    public override void ExecuteAction()
    {
        int damage = Mathf.Max(0, (actor.attack - target.defense));
        float hitrate = Mathf.Max(0, (actor.accuracy - target.avoidance));

        if (Random.Range(0, 100) <= hitrate)
        {
            if (Random.Range(0, 100) <= actor.critChance)
            {
                // Critical Hit
                damage *= 2;
                target.GetDamage(damage);
                target.GetDamage(damage);
            }
            else
            {
                // Hit
                target.GetDamage(damage);
                target.GetDamage(damage);
            }
        }
        else
        {
            // Miss

        }
    }

}
