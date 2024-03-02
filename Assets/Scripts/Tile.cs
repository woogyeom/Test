using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameManager gameManager;

    public Vector2Int position;
    public bool isOccupied;

    public Tile[] neighbors;
    
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
}
