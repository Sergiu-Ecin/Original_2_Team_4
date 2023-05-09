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
    [SerializeField] float fwdVelocity, upVelocity;
    float timer;

    private void Start()
    {
        target = WayPointManager.points[0];
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


    void Cannon()
    {
        Cannone.transform.LookAt(Player_Controller.playerVect + Vector3.up * 10f);

        timer += Time.deltaTime;
        if (timer >= Random.Range(2, 5))
        {
            var proiettile = Instantiate(Proiettile, Fire.transform.position, Fire.rotation);
            proiettile.GetComponent<Rigidbody>().velocity = Fire.up * upVelocity + Fire.forward * fwdVelocity; 
            timer = 0;
        }
    }
}
