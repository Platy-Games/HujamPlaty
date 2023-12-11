using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of ship movement
    public float maxY = 10.0f; // Maximum Y position
    public float minY = -10.0f; // Minimum Y position
    public float tiltAmount = 5f; // Eğilme miktarı
    public float tiltSmoothness = 5f; // Eğilme yumuşaklığı

    private float currentTilt = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        // Rigidbody2D bileşenini al
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get the user input for vertical movement (W for up, S for down)
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1f; // Move up if 'W' key is pressed
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1f; // Move down if 'S' key is pressed
        }

        // Calculate the new position based on the input
        float newY = transform.position.y + (verticalInput * speed * Time.deltaTime);

        // Clamp the new Y position within the defined limits (minY to maxY)
        newY = Mathf.Clamp(newY, minY, maxY);

        // Set the ship's position, restricting movement along the Y-axis
        transform.position = new Vector2(transform.position.x, newY);

        // Eğilme efekti
        if (verticalInput > 0)
        {
            // Yukarı hareket ederken biraz yukarı eğil
            currentTilt = Mathf.Lerp(currentTilt, tiltAmount, tiltSmoothness * Time.deltaTime);
        }
        else if (verticalInput < 0)
        {
            // Aşağı inerken biraz aşağı eğil
            currentTilt = Mathf.Lerp(currentTilt, -tiltAmount, tiltSmoothness * Time.deltaTime);
        }
        else
        {
            // Dikey hareket yoksa düzelt
            currentTilt = Mathf.Lerp(currentTilt, 0f, tiltSmoothness * Time.deltaTime);
        }

        transform.eulerAngles = new Vector3(0f, 0f, currentTilt);
    }
}
