using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int EnemyCount;


    private void Awake()
    {
        print("GameManager Awake");
        instance = this;
    }

    // Update is called once per frame
    public void EnemyKilled()
    {
        Debug.Log("Enemy Killed in UI Manager");
        EnemyCount--;
        UIManager.instance.DecreaseEnemyHUD(EnemyCount);
        
        if (EnemyCount <= 0)
        {
            Debug.Log("GameWin");
        }
    }
}
