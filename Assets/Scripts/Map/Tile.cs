using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameManager gameManager;
    private TileManager tileManager;

    public Vector2Int position;
    private bool isOccupied;
    private Area area;

    private void Start()
    {
        gameManager = GameManager.Instance;
        tileManager = TileManager.Instance;
        position = new Vector2Int((int)transform.position.x, (int)transform.position.y);

        TileManager.Instance.AddTile(this);
    }

    public bool GetIsOccupied()
    {
        return isOccupied;
    }

    public void SetIsOccupied(bool isOccupied)
    {
        this.isOccupied = isOccupied; 
    }

    public Area GetArea()
    {
        return area;
    }

    public void SetArea(Area area)
    {
        this.area = area;
    }

    public void ClearArea()
    {
        area = null;
    }
}
