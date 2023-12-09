using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPos;
    [SerializeField] private float cooldown;
    private void Start()
    {
        _isCooldownOver = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isCooldownOver)
        {
            StartCoroutine(SetCooldown());
            CreateABullet();
        }

    }
    void CreateABullet()
    {
        GameObject instance = Instantiate(bulletPrefab, spawnPos.position, Quaternion.identity);
    }

    private bool _isCooldownOver;
    private IEnumerator SetCooldown()
    {
        _isCooldownOver = false;
        yield return new WaitForSeconds(cooldown);
        _isCooldownOver = true;
    }
}
