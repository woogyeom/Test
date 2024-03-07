using UnityEngine;

public class BaseAttack : Attack
{
    public BaseAttack(Unit attacker, Unit target) : base(attacker, target) {}

    public override void ExecuteAction()
    {
        int damage = (attacker.attack - target.defense);
        float hitrate = (attacker.accuracy - target.avoidance);

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
