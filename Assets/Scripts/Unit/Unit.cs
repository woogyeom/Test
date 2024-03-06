using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector2Int position;

    public int Health { get; set; }
    public int MaxHealth { get; set; }

    public int Attack { get; set; }
    public int Defense { get; set; }

    public float Accuracy { get; set; }
    public float Avoidance { get; set; }
    public float CritChance { get; set; }

    public List<StatusEffect> currentStatusEffects;
    
    public Unit(int maxHealth, int attack, int defense)
    {
        this.MaxHealth = maxHealth;
        Health = maxHealth;
        this.Attack = attack;
        this.Defense = defense;
        Accuracy = 0.95f;
        Avoidance = 0.05f;
        CritChance = 0.1f;
    }

    private void Start()
    {
        position = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        
    }

    public void SetPosition(Vector2Int newPosition)
    {
        position = newPosition;

    }

    public void Move(Direction direction)
    {
        // Move one grid

    }

    public Vector2Int GetPosition()
    {
        return position;
    }

    public void GetDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            // Death
        }
    }

    public void ApplyStatusEffect(StatusEffect effect)
    {
        if (currentStatusEffects.Contains(effect))
        {
            RemoveStatusEffect(effect);
        }
        currentStatusEffects.Add(effect);
    }

    public void RemoveStatusEffect(StatusEffect effect)
    {
        if (currentStatusEffects.Contains(effect))
        {
            currentStatusEffects.Remove(effect);
        }
    }
}
