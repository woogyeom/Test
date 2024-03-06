using UnityEngine;

public class Player : Unit
{
    private GameManager gameManager;

    public Player(int maxHealth, int maxMana, int attack, int defense, float accuracy, float avoidance) 
        : base(maxHealth, maxMana, attack, defense, accuracy, avoidance)
    {
        
    }


    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {

    }
}
