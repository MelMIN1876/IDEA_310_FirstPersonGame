using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    private List<EnemyBehavior> enemies = new List<EnemyBehavior>();

    void Awake()
    {
        Instance = this;
    }

    public void RegisterEnemy(EnemyBehavior enemy)
    {
        if (!enemies.Contains(enemy))
        {
            enemies.Add(enemy);
        }
    }

    public void UnregisterEnemy(EnemyBehavior enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
        }
        CheckAllEnemiesDead();
    }

    void CheckAllEnemiesDead()
    {
        if(enemies.Count == 0)
        {
            Debug.Log("All enemies are dead");
            DoorManager.Instance.OpenDoors();
        }
    }
}
