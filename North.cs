using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f;

    void Update()
    {
        // Get input for movement and rotation
        float moveInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");

        // Move the car forward/backward
        Vector3 movement = transform.forward * moveInput * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Rotate the car
        float rotation = rotateInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotation);
    }
}
