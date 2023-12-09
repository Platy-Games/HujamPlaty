using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    [SerializeField] private  GameObject[] spawnNesneleri; // Spawner tarafından oluşturulacak nesnelerin listesi
    [SerializeField] private float spawnSpeed = 3f; 
    [SerializeField] private float solaDogruHiz = 5f; // Nesnelere eklenecek sola doğru hız
    [SerializeField] private float nesneOmru = 5f; // Nesnenin ömrü (saniye)

    void Start()
    {
        // Belirli aralıklarla SpawnObject fonksiyonunu çağır
        InvokeRepeating("SpawnObject", 0f,1f / spawnSpeed);
    }

    void SpawnObject()
    {
        // Random bir nesne seç
        GameObject selectedObject = spawnNesneleri[Random.Range(0, spawnNesneleri.Length)];

        // Nesneyi ekrana spawn et
        //TODO gemiye denk gelmeyecek şekilde spawn et
        Vector2 spawnPosition = new Vector2(transform.position.x, Random.Range(-5f, 5f));
        GameObject spawnedObject = Instantiate(selectedObject, spawnPosition, Quaternion.identity);

        // Nesnenin RigidBody2D bileşenini al
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();

        // Nesneye sola doğru hız uygula
        if (rb != null)
        {
            rb.velocity = new Vector2(-solaDogruHiz, 0f);
        }
        else
        {
            Debug.LogError("Rigidbody2D bileşeni bulunamadı!");
        }

        // Nesnenin belirli bir süre sonra yok olmasını sağla
        Destroy(spawnedObject, nesneOmru);
    }
}