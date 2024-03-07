using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Unit : MonoBehaviour
{
    TileManager tileManager;

    private Tile tile;

    public int health;
    public int maxHealth;

    public int attack;
    public int defense;

    public float accuracy = 0.95f;
    public float avoidance = 0.05f;
    public float critChance = 0.1f;

    public List<StatusEffect> currentStatusEffects;

    private void UnitStart()
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

    public void GetDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
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
