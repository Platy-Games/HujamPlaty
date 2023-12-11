using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    private Transform _target;
    public float amplitude = 1.0f; // Adjust this value for the height of the patrol movement
    public float speed = 1.0f; // Adjust this value for the speed of the patrol movement

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
        Vector2.Distance(_target.position, transform.position);
        
        Vector2 moveDirection = (_target.position - transform.position).normalized;

        // Move towards the target
        transform.Translate(moveDirection * leftwardSpeed * Time.deltaTime);
        //transform.Translate(isStopped ? new Vector2(0, moveDirection.y) : moveDirection * leftwardSpeed * Time.deltaTime);
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            //TODO animation explosion
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
