using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Klavye girişini al
        float horizontalInput = Input.GetAxis("Horizontal");
        /*float verticalInput = Input.GetAxis("Vertical");*/

        // Hareket vektörünü oluştur
        Vector2 movement = new Vector2(horizontalInput,0/*, verticalInput*/);

        // Rigidbody2D bileşenine hareketi uygula
        GetComponent<Rigidbody2D>().velocity = movement * speed;
    }
}
