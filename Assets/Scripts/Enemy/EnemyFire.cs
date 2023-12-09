using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] private float cooldown;
    private bool _isCooldownOver;

    private void Start()
    {
        _isCooldownOver = true;
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
        GameObject instance = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
    }

    private IEnumerator SetCooldown()
    {
        _isCooldownOver = false;
        yield return new WaitForSeconds(cooldown);
        _isCooldownOver = true;
    }
}
