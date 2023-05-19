using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemyO : MonoBehaviour
{
    float timer;
    [SerializeField] int loop;
    [SerializeField] GameObject Enemy;
    public static Transform[] pointsO;

    private void Awake()
    {
        pointsO = new Transform[transform.childCount];
        for (int i = 0; i < pointsO.Length; i++)
        {
            pointsO[i] = transform.GetChild(i);

            if (i > pointsO.Length)
            {
                i = 0;
            }
        }
    }

    void Start()
    {
        timer = WaveManager.timerSpawner;
    }

    void Update()
    {
        if (WaveManager.startWave == true)
        {
            SpawnEnemy();
        }

    }

    void SpawnEnemy()
    {
        timer += Time.deltaTime;
        if (timer > WaveManager.timerSpawner && WaveManager.countEnemySpawn > 0)
        {
            GameObject pos = Instantiate(Enemy);
            pos.transform.position = transform.position;
            EnemyController ec = pos.GetComponent<EnemyController>();
            if (ec != null)
            {
                ec.ovest = true;
                ec.loop = loop;
            }
            timer = 0;
            WaveManager.countEnemySpawn--;
        }
    }

    private void OnDrawGizmos()
    {

        foreach (Transform t in transform)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(t.position, 1.5f);
        }

        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(loop).position);
    }



}
