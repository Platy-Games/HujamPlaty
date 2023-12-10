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
    [SerializeField] private float bulletStrength;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] public float bulletStrength;

    private UpgradeManager upgradeManager;

    public int upgradeLevel = 0;

    private void Start()
    {
        Destroy(gameObject,DestroyTime);


        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0f;

        direction = (targetPos - transform.position).normalized;


        upgradeManager = FindObjectOfType<UpgradeManager>();

        ApplyUpgrades();

    }
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.transform.TryGetComponent(out HealthCounter healthCounter)) return;
        healthCounter.CurrentHealth -= bulletStrength;
        if (healthCounter.CurrentHealth <= 0f)
        {
            if (other.transform.CompareTag("BigMeteor"))
            {
                var position = other.transform.position;
                Instantiate(meteorPrefab, new Vector3(position.x + 1, position.y + 1),Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(MeteoriteSpawner.solaDogruHiz, 0f);
                Instantiate(meteorPrefab, new Vector3(position.x - 1, position.y - 1), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(MeteoriteSpawner.solaDogruHiz, 0f);
                        
            }

            Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    public void ApplyUpgrades()
    {
        if (upgradeManager != null)
        {
            upgradeManager.ApplyUpgrades(this);
        }
    }
}
