using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    public static bool cicciopasticcio;
    public static Camera camer;

    // Start is called before the first frame update
    void Start()
    {
        camer = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameStatus == GameManager.GameStatus.gameRunning)
        {
            if (cicciopasticcio == false)
            {
                cameraMoove();
            }

            Cursor.lockState = CursorLockMode.Locked;

        }
        else Cursor.lockState = CursorLockMode.None;
    }

    void cameraMoove()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);


    }
}
