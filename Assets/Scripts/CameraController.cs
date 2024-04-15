using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private float Speed = 1.0f;
    [SerializeField] private float RunSpeed = 4.0f;
    [SerializeField] private float Sensitivity = 2.0f;

    private float SavedSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SavedSpeed = Speed;
    }

    private void Update()
    {
        // Show cursor on escape press.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Hide cursor on left mouse button click.
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.F)) Screen.fullScreen = true;

        if (Cursor.visible) return;

        if (Input.GetKeyDown(KeyCode.LeftShift)) Speed = RunSpeed;

        // Move the camera forward, backward, left, and right.
        transform.position += Input.GetAxis("Vertical") * Speed * Time.deltaTime * transform.forward;
        transform.position += Input.GetAxis("Horizontal") * Speed * Time.deltaTime * transform.right;

        // Rotate the camera based on the mouse movement.
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(-mouseY * Sensitivity, mouseX * Sensitivity, 0);

        if (Input.GetKeyUp(KeyCode.LeftShift)) Speed = SavedSpeed;
    }
}
