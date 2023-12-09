using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform _target;

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
        Vector2 moveDirection = (_target.position - transform.position).normalized;

        // Move towards the target
        transform.Translate(moveDirection * leftwardSpeed * Time.deltaTime);
    }
}
