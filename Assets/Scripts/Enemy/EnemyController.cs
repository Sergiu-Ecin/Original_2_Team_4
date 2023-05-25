using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{


    [Header("Stats")]
    [SerializeField] float Hp;
    [SerializeField] float speed;
    [SerializeField] float moneyDrop;
    public static float _moneyDrop;
    [HideInInspector] public int loop;
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

    [SerializeField] float danno;
    public static float takeDanno;

    InventoryManager Im;

    [HideInInspector] public bool nord, sud, est, ovest;
    private void Start()
    {
        if (nord == true)
        {
            target = SpawnerEnemyN.pointsN[0];

        }
        if (ovest == true)
        {
            target = SpawnerEnemyO.pointsO[0];

        }
        if (sud == true)
        {
            target = SpawnerEnemyS.pointsS[0];

        }
        if (est == true)
        {
            target = SpawnerEnemyE.pointsE[0];

        }

        
        moneyDrop = _moneyDrop;
        takeDanno = danno;


        Im = FindObjectOfType<InventoryManager>();
    }


    private void FixedUpdate()
    {
        if (GameManager.gameStatus == GameManager.GameStatus.gameRunning)
            MoveEnemy();
    }

    private void Update()
    {

        Debug.Log(target);
        Debug.Log(waypointIndex);
        Cannon();
        Vita();
    }

    void MoveEnemy()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (ovest == true)
            transform.LookAt(SpawnerEnemyO.pointsO[waypointIndex]);
        if (nord == true)
            transform.LookAt(SpawnerEnemyN.pointsN[waypointIndex]);
        if (sud == true)
            transform.LookAt(SpawnerEnemyS.pointsS[waypointIndex]);
        if (est == true)
            transform.LookAt(SpawnerEnemyE.pointsE[waypointIndex]);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            if (ovest == true)
                NextWayPointO();
            if (nord == true)
                NextWayPointN();
            if (sud == true)
                NextWayPointS();
            if (est == true)
                NextWayPointE();
        }
    }

    private void NextWayPointO()
    {
        waypointIndex++;
        target = SpawnerEnemyO.pointsO[waypointIndex];


        if (waypointIndex >= SpawnerEnemyO.pointsO.Length - 1)
        {
            target = SpawnerEnemyO.pointsO[loop];
            waypointIndex = loop;
        }
    }
    private void NextWayPointN()
    {
        waypointIndex++;
        target = SpawnerEnemyN.pointsN[waypointIndex];


        if (waypointIndex >= SpawnerEnemyN.pointsN.Length - 1)
        {
            target = SpawnerEnemyN.pointsN[loop];
            waypointIndex = loop;
        }
    }

    private void NextWayPointS()
    {
        waypointIndex++;
        target = SpawnerEnemyS.pointsS[waypointIndex];


        if (waypointIndex >= SpawnerEnemyS.pointsS.Length - 1)
        {
            target = SpawnerEnemyS.pointsS[loop];
            waypointIndex = loop;
        }
    }

    private void NextWayPointE()
    {
        waypointIndex++;
        target = SpawnerEnemyE.pointsE[waypointIndex];


        if (waypointIndex >= SpawnerEnemyE.pointsE.Length - 1)
        {
            target = SpawnerEnemyE.pointsE[loop];
            waypointIndex = loop;
        }
    }


    void Cannon()
    {
        Cannone.transform.LookAt(PlayerMovement.playerVect + Vector3.up * 10f);

        timer += Time.deltaTime;
        if (timer >= timeShoot && waypointIndex >= loop)
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
            UIManager.score += moneyDrop;
            Im.money += moneyDrop;
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BulletPlayer")
        {
            Hp -= Turret_Controller2.takeDanno;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Catapult_Bullet")
        {
            Hp -= Catapult_Turret.takeDanno;
            Destroy(other.gameObject);
        }

        //if (other.gameObject.tag == "Ballista_Bullet")
        //{
        //    Hp -= Balista_Turret.takeDanno;
        //    UIManager.score += scoreDrop;
        //    Destroy(other.gameObject);
        //}
    }
}
