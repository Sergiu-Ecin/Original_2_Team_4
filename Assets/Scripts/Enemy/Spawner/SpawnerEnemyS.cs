using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemyS : MonoBehaviour
{
    float timer;
    [SerializeField] int loop;
    [SerializeField] GameObject Enemy;
    public static Transform[] pointsS;

    private void Awake()
    {
        pointsS = new Transform[transform.childCount];
        for (int i = 0; i < pointsS.Length; i++)
        {
            pointsS[i] = transform.GetChild(i);

            if (i > pointsS.Length)
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
                ec.sud = true;
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
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(t.position, 1.5f);
        }

        Gizmos.color = Color.green;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(loop).position);
    }
}
