using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Catapult_Turret : MonoBehaviour
{
    [Header("Vita")]
    [SerializeField] float Hp;

    [Header("Camera")]
    public Transform HorizontalAxis;
    public Transform VerticalAxis;
    public Camera cameraTurret;
    public float sensibilitaMouse = 2f;
    float mouseX, mouseY;
    public Vector2 xMinMax;
    public Vector2 yMinMax;

    [Header("Shooting")]
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject munition;
    [SerializeField] float shootingPower;
    [Range(0.0f, 5f)] public float cooldown;
    public int munitions = 5;
    int actualMunitions;


    [Header("Danno")]
    [SerializeField] float danno;
    public static float takeDanno;

    [Header("AI")]
    public bool AI = true;
    public float fireRate;
    public float aiDamage;
    public float turnSpeed = 4f;
    public float range = 100f;
    public string enemyTag = "Enemy";
    private float fireCountdown;
    private Transform target;

    float timeElapsed = 10f;
    public static bool playerControl = false;

    AudioSource catapulta;

    GameManager gm;
    public void Start()
    {
        gm = FindObjectOfType<GameManager>();
        actualMunitions = munitions;
        if (AI == true)
        {
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
    }

    public void Update()
    {
        if (AI != true)
        {
            if (gm.gameStatus == GameManager.GameStatus.gameRunning)
                visualeMouse();
            if (Hp <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (AI == true)
        {
            if (target == null)
                return;

            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(HorizontalAxis.rotation.normalized, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            HorizontalAxis.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            if (fireCountdown <= 0)
            {
                ShootAi();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void visualeMouse()
    {
        mouseX += Input.GetAxis("Mouse Y") * sensibilitaMouse;
        mouseY += Input.GetAxis("Mouse X") * sensibilitaMouse;

        mouseX = Mathf.Clamp(mouseX, xMinMax.x, xMinMax.y);
        mouseY = Mathf.Clamp(mouseY, yMinMax.x, yMinMax.y);

        HorizontalAxis.eulerAngles = new Vector3(0f, mouseY, 0f);
        VerticalAxis.eulerAngles = new Vector3(mouseX, mouseY, 0f);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        timeElapsed += Time.deltaTime;
        if (timeElapsed >= cooldown && actualMunitions >= 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Audiomanager.catapulta.Play();
                Shoot();
                actualMunitions--;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Recharge();
        }
    }
    void Recharge()
    {
        actualMunitions = munitions;
    }

    void Shoot()
    {
        cooldown += Time.deltaTime;
        takeDanno = danno;
        var bullet = Instantiate(munition, muzzle.position, muzzle.rotation);
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * shootingPower;
        timeElapsed = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyAmmo")
        {
            Hp -= EnemyController.takeDanno;
            Destroy(other.gameObject);
        }
    }

    void ShootAi()
    {
        cooldown += Time.deltaTime;

        takeDanno = aiDamage;
        var bullet = Instantiate(munition, muzzle.position, muzzle.rotation);
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * shootingPower;
        timeElapsed = 0;
    }

    void UpdateTarget()
    {
        if (AI == true)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
    }
}
