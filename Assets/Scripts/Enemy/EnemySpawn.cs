using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //TODO: Enemies does not despawn when collided with Hexagon(OurShip). DamageTaken Script can handle.
    [SerializeField] private GameObject[] enemyPrefabs; // Array of enemy ship prefabs
    [SerializeField] private float spawnSpeed = 3f; // Object spawn rate (per second)
    [SerializeField] private float leftwardSpeed = 5f; // Speed for enemy movement
    [SerializeField] private float objectLifetime = 5f; // Lifetime of the object (in seconds)

    private Transform target; // Reference to the target (e.g., player)

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        // Call the SpawnEnemy function at regular intervals based on spawnSpeed
        InvokeRepeating("SpawnEnemy", 0f, 1f / spawnSpeed);
    }

    void SpawnEnemy()
    {
        // Randomly select an enemy prefab from the array
        GameObject selectedEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Calculate spawn position randomly within a range
        Vector2 spawnPosition = new Vector2(transform.position.x, Random.Range(-5f, 5f));

        // Spawn the selected enemy
        GameObject spawnedEnemy = Instantiate(selectedEnemy, spawnPosition, Quaternion.identity);
        // Rename the spawned enemy
        spawnedEnemy.name = "Enemy";
        // Get the Rigidbody2D component of the spawned enemy
        Rigidbody2D rb = spawnedEnemy.GetComponent<Rigidbody2D>();

        // Apply leftward velocity to the enemy if Rigidbody2D exists
        if (rb != null)
        {
            rb.velocity = new Vector2(-leftwardSpeed, 0f);

            // Disable gravity for the enemy
            rb.gravityScale = 0f;
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found!");
        }

        // Destroy the enemy after a specific lifetime
        Destroy(spawnedEnemy, objectLifetime);

        // Start enemy movement towards the target (player)
        StartCoroutine(MoveTowardsTarget(spawnedEnemy.transform));
    }

    IEnumerator MoveTowardsTarget(Transform enemyTransform)
    {
        while (enemyTransform != null && target != null)
        {
            // Calculate the direction towards the target (player)
            Vector2 moveDirection = (target.position - enemyTransform.position).normalized;

            // Move towards the target
            enemyTransform.Translate(moveDirection * leftwardSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
