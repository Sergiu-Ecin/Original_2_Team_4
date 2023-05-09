using UnityEngine;

public class Turret_Controller : MonoBehaviour
{
    public float sensibilitaMouse = 2f;
    public Transform HorizontalAxis;
    public Transform VerticalAxis;
    float mouseX, mouseY;

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensibilitaMouse;
        mouseY = Input.GetAxis("Mouse Y") * sensibilitaMouse;
        HorizontalAxis.transform.Rotate(0f, mouseX, 0f);
        VerticalAxis.transform.Rotate(-mouseY, 0f, 0f);

        Camera.main.transform.Rotate((-mouseY / 45), 0f, 0f);
    }

}
