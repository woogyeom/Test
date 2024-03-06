using UnityEngine;

public class BaseAttack : Attack
{
    public BaseAttack(Unit attacker, Unit target) : base(attacker, target) {}

    public override void ExecuteAction()
    {
        int damage = (attacker.Attack - target.Defense);
        float hitrate = (attacker.Accuracy - target.Avoidance);

        if (Random.Range(0, 100) <= hitrate)
        {
            // Hit
            target.GetDamage(damage);
        }
        else
        {
            // Miss
        }
    }

}
