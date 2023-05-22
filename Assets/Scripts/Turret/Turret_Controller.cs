using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret_Controller : MonoBehaviour
{
    public float sensibilitaMouse = 2f;
    public Transform HorizontalAxis;
    public Transform VerticalAxis;
    float mouseX, mouseY;

    [Header("Objects")]
    [SerializeField] Transform Muzzle;
    [SerializeField] GameObject proiettile;

    [Header("Variables")]
    [SerializeField] float fwdVelocity;
    [SerializeField] float upVelocity;
    [Range(0.0f, 5f)] public float timer;
    float timeElapsed = 10f;

    [Header("Danno")]
    [SerializeField] float danno;
    public static float takeDanno;



    public Camera[] cameras;
    private int currentCameraIndex = 0;

    public static bool attivo = false;

    public GameObject player;
    

    //float xRotation, yRotation;

    //public Transform orientation;

    //GameManager GM;

    //private void Start()
    //{
    //    GM = FindObjectOfType<GameManager>();
    //}

    //private void Update()
    //{
    //    if (GM.gameStatus == GameManager.GameStatus.gameRunning)
    //    {
    //        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * PlayerPrefs.GetFloat("sensX", 50f);
    //        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * PlayerPrefs.GetFloat("sensY", 50f);

    //        yRotation += mouseX;
    //        xRotation -= mouseY;

    //        xRotation = Mathf.Clamp(xRotation, -90, 90);
    //        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    //        orientation.rotation = Quaternion.Euler(0, yRotation, 0);


    //        Cursor.lockState = CursorLockMode.Locked;
    //        Cursor.visible = false;

    //    }
    //}




    public void Start()
    {
        cameras[0].gameObject.SetActive(true);
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        takeDanno = danno;

    }

    public void Update()
    {

        if (attivo == true)
        {

            mouseX = Input.GetAxis("Mouse X") * sensibilitaMouse;
            mouseY = Input.GetAxis("Mouse Y") * sensibilitaMouse;
            HorizontalAxis.transform.Rotate(0f, mouseX, 0f);
            VerticalAxis.transform.Rotate(-mouseY, 0f, 0f);

            // Camera.main.transform.Rotate((-mouseY / 45), 0f, 0f);

            timeElapsed += Time.deltaTime;
            if (timeElapsed >= timer)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Shoot();
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F) && attivo == false)
        {

            attivo = true;


            cameras[currentCameraIndex].gameObject.SetActive(false);

            // Incrementa l'indice della camera corrente
            currentCameraIndex++;

            // Se l'indice supera il numero di camere, torna alla prima
            if (currentCameraIndex >= cameras.Length)
            {
                currentCameraIndex = 0;
            }

            // Attiva la nuova camera corrente
            cameras[currentCameraIndex].gameObject.SetActive(true);


            player.GetComponent<PlayerMovement>().enabled = false;
              
        }
        else if (Input.GetKeyDown(KeyCode.F) && attivo == true)
        {

            attivo = false;


            cameras[currentCameraIndex].gameObject.SetActive(false);

            // Incrementa l'indice della camera corrente
            currentCameraIndex++;

            // Se l'indice supera il numero di camere, torna alla prima
            if (currentCameraIndex >= cameras.Length)
            {
                currentCameraIndex = 0;
            }

            // Attiva la nuova camera corrente
            cameras[currentCameraIndex].gameObject.SetActive(true);

            player.GetComponent<PlayerMovement>().enabled = true;
        }

    }

    void Shoot()
    {
        timer += Time.deltaTime;

        var bullet = Instantiate(proiettile, Muzzle.position, Muzzle.rotation);
        bullet.GetComponent<Rigidbody>().velocity = Muzzle.forward * fwdVelocity;
        timeElapsed = 0;
    }

}
