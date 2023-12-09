using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class bulletScript : MonoBehaviour
{
    public float DestroyTime;
    public float speed;
    Vector3 targetPos;
    Vector3 direction;
    [SerializeField] private GameObject meteorPrefab;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        var healthCounter = other.transform.GetComponent<HealthCounter>();
        healthCounter.CurrentHealth -= 25;
        if (healthCounter.CurrentHealth <= 0)
        {
            if (other.transform.CompareTag("BigMeteor"))
            {
                var position = other.transform.position;
                Instantiate(meteorPrefab, new Vector3(position.x + 1, position.y + 1),Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(-MeteoriteSpawner.solaDogruHiz, 0f);
                Instantiate(meteorPrefab, new Vector3(position.x - 1, position.y - 1), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(-MeteoriteSpawner.solaDogruHiz, 0f);
                
            }
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
