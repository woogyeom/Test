using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : StatusEffect
{
    private int increasedDefense;

    public Guard(Unit unit) : base(unit)
    {
        increasedDefense = 0;
        duration = 1;
    }

    public override void ApplyEffect()
    {
        increasedDefense = unitAffected.defense * 2;
        unitAffected.defense += increasedDefense;
    }

    public override void RemoveEffect()
    {
        unitAffected.defense -= increasedDefense;
    }
}
