using System;
using UnityEngine;
using UnityEngine.Events;

public class GANCA : MonoBehaviour
{
    [SerializeField] private float donmeHizi = 2.5f;
    [SerializeField] private float maksimumDonmeAci = 180f;
    [SerializeField] private float hareketHizi = 10f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;

    private bool isMovingTowards = false; // Hareket durumunu kontrol etmek için

    void Start()
    {
        // Başlangıç pozisyonunu kaydet
        initialPosition = transform.position;
        targetPosition = initialPosition; // İlk hedef pozisyonunu başlangıç pozisyonu olarak ayarla
    }

    void Update()
    {
        Vector3 farePozisyonu = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(1)) // Sağ tıklandığında
        {
            // Sağ tıklandığında nesnenin rotate olduğu alanda mı kontrol et
            if (IsInRotateArea(farePozisyonu))
            {
                targetPosition = farePozisyonu; // Sağ tıklandığında yeni hedef pozisyonu ayarla
                isMovingTowards = true; // Hareket etme durumunu başlat
            }
        }

        if (isMovingTowards)
        {
            // Sağ tıklanan pozisyona doğru hareket et
            MoveStraightTowards();

            // Eğer hedef konuma ulaşıldıysa, başlangıç pozisyonuna geri dön ve mause takibini bırak
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMovingTowards = false; // Hareket etme durumunu kapat
            }
        }
        else
        {
            // Nesne sadece hareket etmiyorsa ve sağ tıklanmadıysa, sürekli olarak fareyi takip etsin
            RotateTowards(farePozisyonu);
        }
    }

    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        angle = Mathf.Clamp(angle, -maksimumDonmeAci, maksimumDonmeAci);

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, donmeHizi * Time.deltaTime);
    }

    void MoveStraightTowards()
    {
        // Hedef konuma doğru düz bir çizgide ilerle
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, hareketHizi * Time.deltaTime);

        // Eğer hedef konuma ulaşıldıysa, başlangıç pozisyonuna geri dön
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = initialPosition;
        }
    }

    bool IsInRotateArea(Vector3 position)
    {
        // Eğer rotate olduğu alanda ise true döndür
        float angle = Mathf.Atan2(position.y - initialPosition.y, position.x - initialPosition.x) * Mathf.Rad2Deg;
        float currentAngle = transform.eulerAngles.y;
        return Mathf.Abs(Mathf.DeltaAngle(angle, currentAngle)) < maksimumDonmeAci / 2f;
    }
}
