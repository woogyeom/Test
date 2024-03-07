using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blind : StatusEffect
{
    public Blind(Unit unit) : base(unit)
    {
        duration = 2;
    }

    public override void ApplyEffect()
    {
        unitAffected.accuracy -= 0.25f;
    }

    public override void RemoveEffect()
    {
        unitAffected.accuracy += 0.25f;
    }
}
