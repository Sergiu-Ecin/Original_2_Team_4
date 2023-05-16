using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{


    [Header("Stats")]
    [SerializeField] float Hp;
    [SerializeField] float speed;
    [SerializeField] float moneyDrop;
    Transform target;
    int waypointIndex;

    [Header("Cannon")]
    [SerializeField] Transform Fire;
    [SerializeField] GameObject Proiettile, Cannone;
    [SerializeField] float timeShoot, velocit‡Palla;
    [Header("+precisione-")]
    [SerializeField]
    [Range(2f, 3f)]
    float precisione;
    float timer;



    private void Start()
    {
        

        target = SpawnerEnemy.points[0];
       

    }

    private void Update()
    {


        MoveEnemy();
        Cannon();
        Vita();
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
            PallaDiCannone pDC = proiettile.GetComponent<PallaDiCannone>();
            pDC.parabolaY = velocit‡Palla;
            pDC.parabolaZ = velocit‡Palla;
            pDC.precisione = precisione;
            timer = 0;
        }
    }


    void Vita()
    {
        if (Hp <= 0)
        {
            WaveManager.enemyCount--;
            Player_Controller.moneyCount += moneyDrop;
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BulletPlayer")
        {
            Hp -= Turret_Controller.takeDanno;
            Destroy(other.gameObject);
            Debug.Log("Hp " + Hp);
        }
    }
}
