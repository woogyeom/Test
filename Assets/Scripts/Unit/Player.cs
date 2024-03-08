using UnityEngine;

public class Player : Unit
{
    GameManager gameManager;

    private int exp;
    private int maxExp;
    private int level;

    void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.SetPlayer(this);

        UnitStart();
    }
}
