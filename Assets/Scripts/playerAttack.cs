using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPos;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateABullet();
        }

    }
    void CreateABullet()
    {
        GameObject instance = Instantiate(bulletPrefab, spawnPos.position, Quaternion.identity);
    }
}
