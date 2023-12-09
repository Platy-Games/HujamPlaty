using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float DestroyTime;
    public float speed;
    Vector3 targetPos;
    Vector3 direction;
    private void Start()
    {
        Destroy(gameObject,DestroyTime);


        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0f;

        direction = (targetPos - transform.position).normalized;
    }
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
