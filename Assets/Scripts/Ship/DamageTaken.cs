using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{
    private int ShipHealth = 100;

    [SerializeField] private GameObject bigMeteorPrefab;
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private GameObject enemyPrefab;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BigMeteor"))
        {
            ShipHealth -= 25;
            Destroy(collision.gameObject);
            Debug.Log("Ship Health -25 New Health = " + ShipHealth);
        }
        else if (collision.CompareTag("Meteor"))
        {
            ShipHealth -= 15;
            Destroy(collision.gameObject);
            Debug.Log("Ship Health -15 New Health = " + ShipHealth);
            TakeDamage();
        }
        else if (collision.CompareTag("Enemy"))
        {
            ShipHealth -= 30;
            Destroy(collision.gameObject);
            Debug.Log("Ship Health -30 New Health = " + ShipHealth);
        }
    }
    /*if (other.CompareTag("EnemyBullets"))
    {
        ShipHealth -= 20;
        Destroy(other.gameObject);
    }*/
public float immortalTime = 2f; // Ölümsüzlük süresi (saniye)
    public Color damageColor = Color.red; // Hasar rengi
    public float shakeDuration = 0.1f; // Titreme süresi (saniye)
    public float shakeMagnitude = 0.1f; // Titreme şiddeti
    public float immobilizeTime = 0.5f; // Hareket edememe süresi (saniye)

    private bool isImmortal = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Ölümsüzlük süresi kontrolü
        if (isImmortal)
        {
            immortalTime -= Time.deltaTime;
            if (immortalTime <= 0)
            {
                isImmortal = false;
                // Ölümsüzlük süresi bittiğinde rengi geri al
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    // Hasar alma fonksiyonu
    public void TakeDamage()
    {
        if (!isImmortal)
        {
            // Ölümsüzlük süresini başlat
            isImmortal = true;

            // Hasar rengini uygula
            GetComponent<SpriteRenderer>().color = damageColor;

            // Titreme efektini başlat
            StartCoroutine(Shake());

            // Hareket edememe süresini kontrol et
            StartCoroutine(Immobilize());

            // Hasar alındığında yapılacak diğer işlemleri buraya ekleyebilirsiniz
        }
    }

    // Titreme efekti
    private IEnumerator Shake()
    {
        Vector2 originalPosition = rb.position;

        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            rb.position = originalPosition + Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rb.position = originalPosition;
    }

    // Hareket edememe süresi
    private IEnumerator Immobilize()
    {
        rb.velocity = Vector2.zero; // Hareketi durdur

        // Hareket edememe süresince yapılacak işlemleri ekleyebilirsiniz

        yield return new WaitForSeconds(immobilizeTime);

        rb.velocity = Vector2.zero; // Hareketi sıfırla

        // Hareket edememe süresi bittiğinde yapılacak işlemleri ekleyebilirsiniz
    }
}