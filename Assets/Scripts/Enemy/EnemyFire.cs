using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] private float cooldown;
    private bool _isCooldownOver;
    [SerializeField] private GameObject barrel;
    private void Start()
    {
        _isCooldownOver = true;
        barrel = GameObject.Find("FireBarrel");
    }

    private void Update()
    {
        if (_isCooldownOver)
        {
            StartCoroutine(SetCooldown());
            CreateABullet();
        }

    }

    void CreateABullet()
    {
        GameObject instance = Instantiate(bulletPrefab, barrel.transform.position, Quaternion.identity);
    }

    private IEnumerator SetCooldown()
    {
        _isCooldownOver = false;
        yield return new WaitForSeconds(cooldown);
        _isCooldownOver = true;
    }
}
