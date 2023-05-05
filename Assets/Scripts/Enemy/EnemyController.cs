using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed;

    Transform target;
    int waypointIndex = 0;

    private void Start()
    {
        target = WayPointManager.points[0];
    }

    private void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            NextWayPoint();
        }
    }

    private void NextWayPoint()
    {
        waypointIndex++;
        target = WayPointManager.points[waypointIndex];
        transform.LookAt(WayPointManager.points[waypointIndex]);

        if (waypointIndex >= WayPointManager.points.Length - 1)
        {
            target = WayPointManager.points[0];
            waypointIndex = 0;
        }
    }
}
