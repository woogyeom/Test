using UnityEngine;

public class Player : Unit
{
    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.SetPlayer(this);

        UnitStart();
    }
}
