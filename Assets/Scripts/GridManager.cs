using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private static GridManager instance;
    public static GridManager Instance => instance;

    private Dictionary<Unit, Vector2Int> unitPositions = new Dictionary<Unit, Vector2Int>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void RegisterUnit(Unit unit)
    {
        unitPositions.Add(unit, Vector2Int.zero);
    }
    
    public void UpdateUnitPosition(Unit unit, Vector2Int newPosition)
    {
        unitPositions[unit] = newPosition;
    }
}
