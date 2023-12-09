using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float DestroyTime;
    public float speed;
    Vector3 targetPos;
    Vector3 direction;

    private Transform Player;
    [SerializeField] private GameObject meteorPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
        Player = GameObject.FindWithTag("Player").transform;
        targetPos = Player.transform.position;
        targetPos.z = 0f;

        direction = (targetPos - transform.position).normalized;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.transform.TryGetComponent<HealthCounter>(out HealthCounter healthCounter)) return;
        healthCounter.CurrentHealth -= 15;
        if (healthCounter.CurrentHealth <= 0)
        {
            if (other.transform.CompareTag("BigMeteor"))
            {
                var position = other.transform.position;
                Instantiate(meteorPrefab, new Vector3(position.x + 1, position.y + 1), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(-MeteoriteSpawner.solaDogruHiz, 0f);
                Instantiate(meteorPrefab, new Vector3(position.x - 1, position.y - 1), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(-MeteoriteSpawner.solaDogruHiz, 0f);

            }
        }
        Destroy(gameObject);
    }
}
