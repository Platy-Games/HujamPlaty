using UnityEngine;

public class GANCA : MonoBehaviour
{
    [SerializeField] private float donmeHizi = 5f;

    [SerializeField] private float maksimumDonmeAci = 180f;

    void Update()
    {
        Vector3 farePozisyonu = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        farePozisyonu.z = 0f;

        transform.position = transform.position;
        RotateTowards(farePozisyonu);
    }

    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        angle = Mathf.Clamp(angle, -maksimumDonmeAci, maksimumDonmeAci);

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, donmeHizi * Time.deltaTime);
    }
}
