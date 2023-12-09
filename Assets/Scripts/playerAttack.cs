using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform _spawnPos;
    [SerializeField] private float cooldown;
    private void Start()
    {
        _spawnPos = GetComponent<Transform>();
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
        GameObject instance = Instantiate(bulletPrefab, _spawnPos.position, Quaternion.identity);
    }

    private bool _isCooldownOver;
    private IEnumerator SetCooldown()
    {
        _isCooldownOver = false;
        yield return new WaitForSeconds(cooldown);
        _isCooldownOver = true;
    }
}
