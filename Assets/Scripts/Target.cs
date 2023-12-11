using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float flashDuration = 0.1f; // Kırmızı renk süresi
    private SpriteRenderer spriteRenderer; // Sprite Renderer componenti
    private Color originalColor; // Orijinal renk

    public float shakeDuration = 0.2f; // Sarsılma süresi
    public float shakeMagnitude = 0.05f; // Sarsılma büyüklüğü
    private Vector3 originalPosition; // Orijinal pozisyon

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Sprite Renderer componentini al
        originalColor = spriteRenderer.color; // Orijinal rengi kaydet
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet")) // Eğer mermi ile temas ederse
        {
            StartCoroutine(Flash()); // Kırmızı renk Coroutine'ini başlat
            StartCoroutine(Shake()); // Sarsılma Coroutine'ini başlat
        }
    }

    private IEnumerator Flash()
    {
        spriteRenderer.color = Color.red; // Rengi kırmızı yap
        yield return new WaitForSeconds(flashDuration); // Belirli bir süre bekle
        spriteRenderer.color = originalColor; // Rengi orijinal rengine geri döndür
    }
    private IEnumerator Shake()
    {
        float elapsed = 0f; // Geçen süre
        while (elapsed < shakeDuration) // Süre bitene kadar
        {
            originalPosition = transform.position; // Orijinal pozisyonu kaydet
            Vector3 randomDirection = Random.insideUnitCircle * shakeMagnitude; // Rastgele bir yön belirle
            transform.position = originalPosition + randomDirection; // Pozisyonu orijinal pozisyona göre değiştir
            elapsed += Time.deltaTime; // Geçen süreyi güncelle
            yield return null; // Bir sonraki frame'e geç
        }
        transform.position = originalPosition; // Pozisyonu orijinal pozisyona geri döndür
    }
}
