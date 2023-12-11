using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{
    public int ShipHealth = 100;




    [SerializeField] private GameObject bigMeteorPrefab;
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject EnemyBulletsPrefab;
    [SerializeField] private GameObject EnemyBulletsPrefabStraight;
    private UpgradeManager upgradeManager;

    [SerializeField] private GameObject explosionPrefab;

    public int upgradeLevel = 0;

    private void Start()
    {
        upgradeManager = FindObjectOfType<UpgradeManager>();

        ApplyUpgrades1();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BigMeteor"))
        {
            Instantiate(explosionPrefab, collision.transform.position,Quaternion.identity);
            ShipHealth -= 25;
            Destroy(collision.gameObject);
            Debug.Log("Ship Health -25 New Health = " + ShipHealth);
            TakeDamage(); 
        }
        else if (collision.CompareTag("Meteor"))
        {
            Instantiate(explosionPrefab, collision.transform.position,Quaternion.identity);
            ShipHealth -= 15;
            Destroy(collision.gameObject);
            Debug.Log("Ship Health -15 New Health = " + ShipHealth);
            TakeDamage();
        }
        else if (collision.CompareTag("Enemy"))
        {
            Instantiate(explosionPrefab, collision.transform.position,Quaternion.identity);
            ShipHealth -= 30;
            Destroy(collision.gameObject);
            Debug.Log("Ship Health -30 New Health = " + ShipHealth);
            TakeDamage();
        }
        else if (collision.CompareTag("EnemyBullets"))
        {
            ShipHealth -= 20;
            Destroy(collision.gameObject);
            Debug.Log("Ship Health -20 New Health = " + ShipHealth);
            TakeDamage();
        }
    }

    /////////////////////////////////////////////////////////////// Player Damage Alma Efektleri (renk , sarsılma, hareket edememe)
    
    [SerializeField] private float flashDuration = 0.2f; // Yanıp sönme süresi
    [SerializeField] private Color flashColor = Color.red; // Yanıp sönme rengi
    private SpriteRenderer spriteRenderer; // Sprite Renderer componenti
    private Color originalColor; // Orijinal renk

    [SerializeField] private float shakeDuration = 0.5f; // Sallanma süresi
    [SerializeField] private float shakeMagnitude = 0.1f; // Sallanma büyüklüğü
    private Vector3 originalPosition; // Orijinal pozisyon

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); // Sprite Renderer componentini al
        originalColor = spriteRenderer.color; // Orijinal rengi kaydet
        
    }

    public void TakeDamage()
    {
        StartCoroutine(Flash()); // Yanıp sönme Coroutine'ini başlat
        StartCoroutine(Shake()); // Sallanma Coroutine'ini başlat
    }

     private IEnumerator Flash()
    {
        spriteRenderer.color = flashColor; // Rengi yanıp sönme rengine değiştir
        yield return new WaitForSeconds(flashDuration); // Belirli bir süre bekle
        spriteRenderer.color = originalColor; // Rengi orijinal rengine geri döndür
    }

    private IEnumerator Shake()
    {
        originalPosition = transform.position; // Orijinal pozisyonu kaydet
        float elapsed = 0f; //geçen süre
        while (elapsed < shakeDuration) //Süre bitene kadar
        {
            Vector3 randomDirection = Random.insideUnitCircle*shakeMagnitude; // Rastgele bir yön belirle
            transform.position = originalPosition + randomDirection; // Pozisyonu orjinal pozisyona göre değiştir
            elapsed += Time.deltaTime; 
            yield return null; //Bir sonraki frame e geç
        }
        transform.position = originalPosition; // pozisyonu orjinal pozisyona geri getir
    }
    
    

    public void ApplyUpgrades1()
    {
        if (upgradeManager != null)
        {
            upgradeManager.ApplyUpgrades1(this);
        }
    }
}