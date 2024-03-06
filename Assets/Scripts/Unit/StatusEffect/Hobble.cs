using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hobble : StatusEffect
{
    public Hobble(Unit unit) : base(unit) {}

    public override void ApplyEffect()
    {
        unitAffected.Avoidance -= 0.2f;
    }

    public override void RemoveEffect()
    {
        unitAffected.Avoidance += 0.2f;
    }
}
