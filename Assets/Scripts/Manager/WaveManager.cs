using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] float timeNextWave;
    public static int enemyCount;
    public static bool startWave;
    public static int countEnemySpawn;
    public static float timerSpawner;
    bool nextWave;

    [Header("Incremento")]
    [SerializeField] float timeSpawn;
    [SerializeField] float DannoEnemy;
    [SerializeField] float TimeNextWave;
    [SerializeField] float MoneyEndWave;
    [SerializeField] float MoneyDropEnemy;
    [SerializeField] int maxEnemyCount, EnemyNextWave;

    InventoryManager iM;
    RayPlayerCamera rPC;

    void Start()
    {
        iM = FindObjectOfType<InventoryManager>();
        rPC = FindObjectOfType<RayPlayerCamera>();
        enemyCount = maxEnemyCount;
        countEnemySpawn = enemyCount;
        timerSpawner = timeSpawn;
    }

    void Update()
    {
        StartWave();
        NextWave();
        TimeWave();
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
            maxEnemyCount += EnemyNextWave;
            enemyCount = maxEnemyCount;
            countEnemySpawn = maxEnemyCount;
            timerSpawner = timeSpawn;
            EnemyController.takeDanno += DannoEnemy;
            iM.money += MoneyEndWave;
            EnemyController._moneyDrop += MoneyDropEnemy;
            timeNextWave += TimeNextWave;
            rPC.wave = false;
            nextWave = false;
            timer = true;
        }
    }

    float time;
    bool timer;
    void TimeWave()
    {
        time += Time.deltaTime;

        if(time >= timeNextWave && timer == true)
        {
            nextWave = true;
            timer = false;
            rPC.wave = true;
            time = 0;
        }
    }

}