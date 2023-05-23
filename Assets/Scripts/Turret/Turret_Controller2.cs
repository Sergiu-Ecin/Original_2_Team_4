using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Turret_Controller2 : MonoBehaviour
{
    [Header("Camera")]
    public Transform HorizontalAxis;
    public Transform VerticalAxis;
    public float sensibilitaMouse = 2f;
    float mouseX, mouseY;
    public Vector2 xMinMax;
    public Vector2 yMinMax;

    [Header("Shooting")]
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject munition;
    [SerializeField] float shootingPower;
    [SerializeField] float damage;
    [Range(0.0f, 5f)] public float cooldown;
    public int munitions = 5;
    int actualMunitions;


    float timeElapsed = 10f;
    public static bool playerControl = false;

    private void Start()
    {
        actualMunitions = munitions;
    }

    private void Update()
    {
        mouseX += Input.GetAxis("Mouse Y") * sensibilitaMouse;
        mouseY -= Input.GetAxis("Mouse X") * sensibilitaMouse;

        mouseX = Mathf.Clamp(mouseX, xMinMax.x, xMinMax.y);
        mouseY = Mathf.Clamp(mouseY, yMinMax.x, yMinMax.y);

        HorizontalAxis.eulerAngles = new Vector3(0f, mouseY, 0f);
        VerticalAxis.eulerAngles = new Vector3(mouseX, mouseY, 0f);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        timeElapsed += Time.deltaTime;
        if (timeElapsed >= cooldown)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Recharge();
        }
    }

    void Shoot()
    {
        cooldown += Time.deltaTime;

        var bullet = Instantiate(munition, muzzle.position, muzzle.rotation);
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * shootingPower;
        timeElapsed = 0;
    }

    void Recharge()
    {
        actualMunitions = munitions;
    }

}
