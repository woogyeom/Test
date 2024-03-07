using UnityEngine;

public class Defend : Move
{
    public Defend(Unit actor) : base(actor) {}

    public override void ExecuteAction()
    {
        StatusEffect guard = new Guard(actor);
        actor.ApplyStatusEffect(guard);
    }

}
