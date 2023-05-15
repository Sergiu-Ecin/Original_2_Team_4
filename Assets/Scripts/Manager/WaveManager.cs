using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] int maxEnemyCount, incrementoEnemyNextWave;
    [SerializeField] float timeSpawn;
    public static int enemyCount;
    public static bool startWave;
    public static int countEnemySpawn;
    public static float timerSpawner;
    bool nextWave;

    void Start()
    {
        enemyCount = maxEnemyCount;
        countEnemySpawn = enemyCount;
        timerSpawner = timeSpawn;
    }

    void Update()
    {
        StartWave();
        NextWave();
    }

    void StartWave()
    {
        if (Input.GetKeyDown(KeyCode.P) && startWave == false)
        {
            startWave = true;
            nextWave = true;
            Debug.Log("Startasti cumpà");
        }
    }


    void NextWave()
    {
        if (enemyCount == 0 && nextWave == true)
        {
            maxEnemyCount += incrementoEnemyNextWave;
            enemyCount = maxEnemyCount;
            countEnemySpawn = maxEnemyCount;
            timerSpawner = timeSpawn;
            startWave = false;
            nextWave = false;
        }
    }
}