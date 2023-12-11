using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform _spawnPos;
    [SerializeField] private float cooldown;

    private UpgradeManager upgradeManager;

    public int upgradeLevel = 0;

    private void Start()
    {
        _spawnPos = GetComponent<Transform>();
        _isCooldownOver = true;
        
        upgradeManager = FindObjectOfType<UpgradeManager>();

        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isCooldownOver)
        {
            StartCoroutine(SetCooldown());
            CreateABullet();
            ApplyUpgrades2();
        }

    }
    public void CreateABullet()
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

    public void ApplyUpgrades2()
    {
        if (upgradeManager != null)
        {
            upgradeManager.ApplyUpgrades2(this);
            Debug.Log("2.projectile spawn");
        }
    }
}
