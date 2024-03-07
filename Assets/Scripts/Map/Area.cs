using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private Dictionary<Vector2Int, Tile> tileDict;
    
    public void AddTile(Tile tile)
    {
        tileDict[tile.position] = tile;
        tile.SetArea(this);
    }

    public void RemoveTile(Vector2Int position)
    {
        if (tileDict.ContainsKey(position))
        {
            tileDict[position].ClearArea();
            tileDict.Remove(position);
        }
    }

    public Dictionary<Vector2Int, Tile> GetTileDict()
    {
        return tileDict;
    }

}
