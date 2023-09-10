using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private float Speed = 1.0f;
    [SerializeField] private float Sensitivity = 5.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Move the camera forward, backward, left, and right
        transform.position += Input.GetAxis("Vertical") * Speed * Time.deltaTime * transform.forward;
        transform.position += Input.GetAxis("Horizontal") * Speed * Time.deltaTime * transform.right;

        // Rotate the camera based on the mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(-mouseY * Sensitivity, mouseX * Sensitivity, 0);
    }
}
