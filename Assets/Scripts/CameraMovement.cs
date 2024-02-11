using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Player object to follow
    public Vector3 offset = new Vector3(0f, 1.5f, -2.5f); // Offset from the player's position
    public float damping = 5.0f; // Speed of camera movement
    public float rotationSpeed = 3.0f; // Speed of camera rotation

    private float mouseX, mouseY;

    void LateUpdate()
    {
        // Rotate the camera based on mouse input
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        // Calculate desired rotation
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

        // Calculate desired position based on player's position and offset
        Vector3 desiredPosition = target.position + rotation * offset;

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);

        // Make the camera look at the player's position
        transform.LookAt(target.position);
    }
}