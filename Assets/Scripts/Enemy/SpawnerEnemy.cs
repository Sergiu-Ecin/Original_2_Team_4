using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] int maxCountEnemy;
    [SerializeField] float timerSpawner;
    float timer;

    [SerializeField] GameObject Enemy;

    void Start()
    {
        timer = timerSpawner;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timerSpawner &&  maxCountEnemy > 0)
        {
            GameObject pos = Instantiate(Enemy);
            pos.transform.position = transform.position;
            timer = 0;
            maxCountEnemy--;
        }
    }
}
