using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameManager gameManager;
    private TileManager tileManager;

    public Vector2Int position;
    public enum TileType
    {
        Floor,
        Wall,
        Player,
        Enemy,
        Obstacle
    }
    private TileType tileType;
    private Room room;

    private void Start()
    {
        gameManager = GameManager.Instance;
        tileManager = TileManager.Instance;
        position = new Vector2Int((int)transform.position.x, (int)transform.position.y);

        TileManager.Instance.AddTile(this);
    }

    public TileType GetTileType()
    {
        return tileType;
    }

    public void SetTileType(TileType tileType)
    {
        this.tileType = tileType; 
    }

    public Room GetRoom()
    {
        return room;
    }

    public void SetRoom(Room room)
    {
        this.room = room;
    }

    public void ClearRoom()
    {
        room = null;
    }
}
