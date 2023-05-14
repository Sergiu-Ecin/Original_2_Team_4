using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] float speed;
    Transform target;
    int waypointIndex;

    [Header("Cannon")]
    [SerializeField] Transform Fire;
    [SerializeField] GameObject Proiettile, Cannone;
    [SerializeField] float timeShoot;
    float timer;

    private void Start()
    {
        target = SpawnerEnemy.points[0];
    }

    private void Update()
    {
        MoveEnemy();
        Cannon();
    }

    void MoveEnemy()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(SpawnerEnemy.points[waypointIndex]);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            NextWayPoint();
        }
    }

    private void NextWayPoint()
    {
        waypointIndex++;
        target = SpawnerEnemy.points[waypointIndex];


        if (waypointIndex >= SpawnerEnemy.points.Length - 1)
        {
            target = SpawnerEnemy.points[0];
            waypointIndex = 0;
        }
    }


    void Cannon()
    {
        Cannone.transform.LookAt(Player_Controller.playerVect + Vector3.up * 10f);

        timer += Time.deltaTime;
        if (timer >= timeShoot)
        {
            var proiettile = Instantiate(Proiettile, Fire.transform.position, Fire.rotation);
            // proiettile.GetComponent<Rigidbody>().velocity = Fire.up * upVelocity + Fire.forward * fwdVelocity; 
            // proiettile.transform.Translate(Fire.up * upVelocity + Fire.forward * fwdVelocity);
            timer = 0;
        }
    }
}
