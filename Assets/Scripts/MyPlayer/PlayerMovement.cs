using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jump = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public static Vector3 playerVect;
    public static Camera cam;
    [SerializeField] Camera camera ;
    [SerializeField] GameObject morte;

    GameManager gm;
    void Start()
    {
        cam = camera;
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerVect = transform.position;
        if (gm.gameStatus == GameManager.GameStatus.gameRunning)
            if (Turret_Controller2.playerControl == false)
            {
                PlayerMove();
                cam.enabled = true;
                
            } else if (Turret_Controller2.playerControl == true)
            {
                cam.enabled = false;
            }
    }

    void PlayerMove()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Morte")
        {
            transform.position = morte.transform.position;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyAmmo")
            gm.EndGame();
    }

}