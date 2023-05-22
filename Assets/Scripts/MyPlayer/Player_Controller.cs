using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    private Vector2 mouseDelta;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    public float camCurXRot;
    public float lookSensitivity;

    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;

    public float jumpForce;
    public LayerMask groundLayerMask;

    public float smoothTime = 0.5f;
    private bool isJumping = false;
    private Vector3 currentVelocity;

    public static Vector3 playerVect;



    [SerializeField] GameObject Respawn;

    public void Start()
    {
        // lock the cursor at the start of the game
        Cursor.lockState = CursorLockMode.Locked;


    }

    public void Update()
    {
        playerVect = transform.position;


        

    }

    // called when we move our mouse - managed by the Input System
    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void LateUpdate()
    {
        if (Turret_Controller.attivo == false)
        {

            CameraLook();
            cameraContainer.gameObject.SetActive(true);

        }
    }

    public void CameraLook()
    {
        // rotate the camera container up and down
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        // rotate the player left and right
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    // called when we press WASD - managed by the Input System
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        // are we holding down a movement button?
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        // have we let go of a movement button?
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    void FixedUpdate()
    {

        if (Turret_Controller.attivo == false)
        {
            Move();
        }

    }
    void Move()
    {
        // calculate the move direction relative to where we're facing.
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rig.velocity.y;
        // assign our Rigidbody velocity
        rig.velocity = dir;
    }

    // components
    private Rigidbody rig;
    void Awake()
    {
        // get our components
        rig = GetComponent<Rigidbody>();
    }


    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
         new Ray(transform.position + (transform.forward * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
         new Ray(transform.position + (-transform.forward * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
         new Ray(transform.position + (transform.right * 0.2f) + (Vector3.up * 0.01f),Vector3.down),
         new Ray(transform.position + (-transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down)
        };
        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }



    //called when we press down on the spacebar - managed by the Input System
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        // is this the first frame we're pressing the button?
        if (context.phase == InputActionPhase.Started)
        {
            // are we standing on the ground?
            if (IsGrounded())
            {
                // add force updwards
                rig.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                StartCoroutine(SmoothJump(rig));
            }




        }
    }

    private IEnumerator SmoothJump(Rigidbody rb)
    {
        float elapsedTime = 0f;
        bool isJumpingUp = true;

        while (elapsedTime < smoothTime && isJumpingUp)
        {
            float jumpPercentage = elapsedTime / smoothTime;
            float yOffset = Mathf.Lerp(0f, jumpForce, jumpPercentage);
            rb.transform.Translate(Vector3.up * yOffset * Time.deltaTime);

            // Check for collision with walls
            RaycastHit hit;
            float sphereRadius = GetComponent<Collider>().bounds.extents.x;
            Vector3 sphereCenter = transform.position + Vector3.up * sphereRadius;
            if (Physics.SphereCast(sphereCenter, sphereRadius, Vector3.right, out hit, 0.1f))
            {
                isJumpingUp = false;
                break;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isJumping = false;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(transform.position + (transform.forward * 0.2f), Vector3.down);
        Gizmos.DrawRay(transform.position + (-transform.forward * 0.2f), Vector3.down);
        Gizmos.DrawRay(transform.position + (transform.right * 0.2f), Vector3.down);
        Gizmos.DrawRay(transform.position + (-transform.right * 0.2f), Vector3.down);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyAmmo" && Turret_Controller.attivo == false) 
        {
            transform.position = Respawn.transform.position;
            Destroy(other.gameObject);
        }
    }


}
