using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float tiltAmount = 5f; // Eğilme miktarı
    [SerializeField] private float tiltSmoothness = 5f; // Eğilme yumuşaklığı

    private float currentTilt = 0f;
    private Rigidbody2D rb;
    private Camera mainCamera;

    void Start()
    {
        // Rigidbody2D ve kamera bileşenlerini al
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Input'lara tepki verme
        float verticalInput = Input.GetAxis("Vertical");

        // Hareket etme
        Vector2 movement = new Vector2(0f, verticalInput);
        rb.velocity = movement * moveSpeed;

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

        // Karakterin kamera dışına çıkmasını engelle
        ClampPosition();
    }

    void ClampPosition()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);

        transform.position = mainCamera.ViewportToWorldPoint(viewPos);
    }
}