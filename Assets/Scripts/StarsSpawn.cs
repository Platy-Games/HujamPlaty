using UnityEngine;

public class StarSpawn : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval = 2f; // Her spawn arası beklenmesi gereken süre (örneğin, 2 saniye)
    [SerializeField] private float destroyDelay = 5f; // Yok olma süresi (örneğin, 5 saniye)

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        // Belirli bir aralıkta spawn işlemini gerçekleştir
        if (timeSinceLastSpawn >= spawnInterval)
        {
            Spawn();
            timeSinceLastSpawn = 0f; // Zamanı sıfırla
        }
    }

    void Spawn()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
        Destroy(spawnedObject, destroyDelay);
    }
}
