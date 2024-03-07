using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private static TileManager instance;
    public static TileManager Instance => instance;

    private Dictionary<Vector2Int, Tile> tileDict = new();

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

    public void AddTile(Tile tile)
    {
        tileDict.Add(tile.position, tile);
    }

    public Tile GetTile(Vector2Int position)
    {
        tileDict.TryGetValue(position, out Tile tile);
        return tile;
    }

    public Vector2Int GetPosition(Tile tile)
    {
        foreach (var kvp in tileDict)
        {
            if (kvp.Value == tile)
            {
                return kvp.Key;
            }
        }
        return Vector2Int.zero;
    }

    public void RemoveTile(Vector2Int position)
    {
        tileDict.Remove(position);
    }
}
