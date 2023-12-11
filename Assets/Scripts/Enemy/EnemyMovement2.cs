using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    private Transform _target;
    private bool isStopped;
    public float amplitude = 1.0f; // Adjust this value for the height of the patrol movement
    public float speed = 1.0f; // Adjust this value for the speed of the patrol movement

    private Vector3 startPosition;
    [SerializeField] private float leftwardSpeed = 5f;
    // Start is called before the first frame update
    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_target == null) return;
        // Calculate the direction towards the target (player)
        if (Vector2.Distance(_target.position,transform.position) <= 7)
        {
            isStopped = true;
        }
        Vector2 moveDirection = (_target.position - transform.position).normalized;

        // Move towards the target
        transform.Translate(isStopped ? new Vector2(0, moveDirection.y) : moveDirection * leftwardSpeed * Time.deltaTime);
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player") &&
        !other.gameObject.CompareTag("Enemy") &&
        !other.gameObject.CompareTag("Enemy") &&
        !other.gameObject.CompareTag("Enemy"))
        {
            // TODO: Animation explosion
            Destroy(other.gameObject);
            //Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            // Ignore collision with objects tagged as "Enemy"
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.collider, true);
        }
    }
}
