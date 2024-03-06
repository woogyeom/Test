using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blind : StatusEffect
{
    public Blind(Unit unit) : base(unit) {}

    public override void ApplyEffect()
    {
        unitAffected.Accuracy -= 0.25f;
    }

    public override void RemoveEffect()
    {
        unitAffected.Accuracy += 0.25f;
    }
}