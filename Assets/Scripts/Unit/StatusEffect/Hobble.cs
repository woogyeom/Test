using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hobble : StatusEffect
{
    public Hobble(Unit unit) : base(unit)
    {
        duration = 2;
    }

    public override void ApplyEffect()
    {
        unitAffected.avoidance -= 0.25f;
    }

    public override void RemoveEffect()
    {
        unitAffected.avoidance += 0.25f;
    }
}
