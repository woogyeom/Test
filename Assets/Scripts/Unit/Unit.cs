using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Unit : MonoBehaviour
{
    TileManager tileManager;

    private Tile tile;

    private int health;
    private int maxHealth;

    public int attack;
    public int defense;

    public float accuracy = 0.95f;
    public float avoidance = 0.05f;
    public float critChance = 0.1f;

    public List<StatusEffect> currentStatusEffects;

    protected void UnitStart()
    {
        tileManager = TileManager.Instance;

        Vector2Int position = new((int)transform.position.x, (int)transform.position.y);
        tile = tileManager.GetTile(position);
    }

    public void SetPosition(Tile tile)
    {
        Vector2Int position = tileManager.GetPosition(tile);
        transform.position = new Vector3(position.x, position.y);
    }

    public Tile GetPosition()
    {
        Vector2Int position = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        tile = tileManager.GetTile(position);
        return tile;
    }

    public (int damage, bool crit) CalculateDamage(Unit target)
    {
        int damage = Mathf.Max(attack - target.defense, 0);
        float hitrate = accuracy - target.avoidance;
        bool crit = false;
        if (Random.Range(0, 100) <= hitrate)
        {
            if (Random.Range(0, 100) <= critChance)
            {
                damage *= 2;
                crit = true;
            }
        }
        else damage = 0;
        return (damage, crit);
    }

    public void GetDamage(int damage, bool crit)
    {
        if (damage < 0) return;
        health -= damage;
        if (health <= 0)
        {
            // Death
        }
    }
    
    public void GetHealed(int heal)
    {
        if (heal < 0) return;
        health = Mathf.Max(health + heal, maxHealth);
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

    public void TurnUpdate()
    {
        if (currentStatusEffects.Count != 0)
        {
            foreach (StatusEffect effect in currentStatusEffects)
            {
                effect.UpdateDuration();
            }
        }
    }

    public void Idle()
    {
        
    }

    public void Move(Direction direction)
    {
        // Move one tile
        Vector2Int newVector = tileManager.GetPosition(tile) + TileManager.GetDirectionVector(direction); 
        tileManager.GetTile(newVector);

    }
}
