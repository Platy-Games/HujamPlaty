using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of ship movement
    public float maxY = 10.0f; // Maximum Y position
    public float minY = -10.0f; // Minimum Y position

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
    }
}
