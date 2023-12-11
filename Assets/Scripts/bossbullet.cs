using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossbullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed;
    public float destroyTime = 2;
    private Collider2D _thisCollider;
    [SerializeField] private GameObject meteorPrefab;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right*bulletSpeed;
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == _thisCollider) return;
        if (!other.transform.TryGetComponent(out HealthCounter healthCounter)) return;
        healthCounter.CurrentHealth -= 15;
        if (healthCounter.CurrentHealth <= 0)
        {
            if (other.transform.CompareTag("BigMeteor"))
            {
                var position = other.transform.position;
                Instantiate(meteorPrefab, new Vector3(position.x + 1, position.y + 1), Quaternion.identity)
                    .GetComponent<Rigidbody2D>().velocity = new Vector2(-MeteoriteSpawner.solaDogruHiz, 0f);
                Instantiate(meteorPrefab, new Vector3(position.x - 1, position.y - 1), Quaternion.identity)
                    .GetComponent<Rigidbody2D>().velocity = new Vector2(-MeteoriteSpawner.solaDogruHiz, 0f);
            }
        }

    }
}
