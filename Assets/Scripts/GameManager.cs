using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] private bool isPlayerTurn = true;
    [SerializeField] private List<Enemy> enemies;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        enemies = new List<Enemy>();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public bool IsPlayerTurn()
    {
        return isPlayerTurn;
    }

    public void EndTurn()
    {
        isPlayerTurn = !isPlayerTurn;

        if (isPlayerTurn)
        {
            // Player Turn Starts
            Debug.Log("Player Turn!");
        }
        else
        {
            // Enemy Turn Starts
            Debug.Log("Enemy Turn!");
            ExecuteEnemyActions();
        }
    }

    private void ExecuteEnemyActions()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.ExecuteAction();
        }

        EndTurn();
    }
}
