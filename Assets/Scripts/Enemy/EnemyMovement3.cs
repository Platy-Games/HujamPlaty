using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement3 : MonoBehaviour
{
    private Transform _target;

    public float upwardPoint;
    public float downwardPoint;
    public float patrolSpeed = 3.0f;

    private bool movingUpward;

    private void Start()
    {
        movingUpward = true;
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (_target == null) return;

        if (Mathf.Abs(_target.position.x - transform.position.x) <= 7)
        {
            MoveBetweenPoints();
        }
        else
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 moveDirection = (_target.position - transform.position).normalized;
        transform.Translate(moveDirection * patrolSpeed * Time.deltaTime);
    }

    private void MoveBetweenPoints()
    {

        Vector2 movement;

        if (!movingUpward)
        {
            movement = Vector2.down * patrolSpeed * Time.deltaTime;
        }
        else
        {
            movement = Vector2.up * patrolSpeed * Time.deltaTime;
        }

        transform.Translate(movement);

        // Check if the enemy reached the target point within a tolerance

        if (transform.position.y >= upwardPoint)
        {
            movingUpward = false;
        }
        else if(transform.position.y <= downwardPoint)
        {
            movingUpward = true;
        }

    }
    [SerializeField] private GameObject explosionPrefab;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player") &&
        !other.gameObject.CompareTag("Enemy") &&
        !other.gameObject.CompareTag("Enemy") &&
        !other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            // Ignore collision with objects tagged as "Enemy"
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.collider, true);
        }
    }
}
