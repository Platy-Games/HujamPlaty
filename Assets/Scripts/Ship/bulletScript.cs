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
    GameObject firePoints;
    GameObject firePoints1;
    GameObject firePoints2;
    GameObject firePoints3;
    GameObject BOSShip;
    private void Start()
    {
        Destroy(gameObject,DestroyTime);

        BOSShip = GameObject.FindGameObjectWithTag("BOSShip");


        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0f;

        direction = (targetPos - transform.position).normalized;

        firePoints = GameObject.FindGameObjectWithTag("firepoint");
        firePoints1 = GameObject.FindGameObjectWithTag("firepoint1");
        firePoints2 = GameObject.FindGameObjectWithTag("firepoint2");
        firePoints3 = GameObject.FindGameObjectWithTag("firepoint3");
    }
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("Collided");
        if (!other.transform.TryGetComponent(out HealthCounter healthCounter)) return;
        healthCounter.CurrentHealth -= bulletStrength;
        if (healthCounter.CurrentHealth <= 0f)
        {
            if (other.transform.CompareTag("BOSShip"))
            {
                firePoints.SetActive(false);
                firePoints1.SetActive(false);
                firePoints2.SetActive(false);
                firePoints3.SetActive(false);
                BOSShip.SetActive(false);
            }
            
            if (other.transform.CompareTag("BigMeteor"))
            {
                var position = other.transform.position;
                Instantiate(meteorPrefab, new Vector3(position.x + 1, position.y + 1),Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(MeteoriteSpawner.solaDogruHiz, 0f);
                Instantiate(meteorPrefab, new Vector3(position.x - 1, position.y - 1), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(MeteoriteSpawner.solaDogruHiz, 0f);
                        
            }

            Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            
        }
        Destroy(gameObject);
    }
}
