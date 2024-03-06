using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameManager gameManager;

    public Vector2Int position;
    public enum TileType
    {
        Floor,
        Wall,
        Player,
        Enemy,
        Obstacle
    }
    private Room room;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void SetTileType()
    {
        
    }

    public void SetRoom(Room room)
    {
        this.room = room;
    }

    public void ClearRoom()
    {
        room = null;
    }

    public Room GetRoom()
    {
        return room;
    }
}
