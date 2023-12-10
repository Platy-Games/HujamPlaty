using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{
    public int ShipHealth = 100;

    [SerializeField] private GameObject bigMeteorPrefab;
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject EnemyBulletsPrefab;
    
    private UpgradeManager upgradeManager;

    public int upgradeLevel = 0;

    private void Start()
    {
        upgradeManager = FindObjectOfType<UpgradeManager>();

        ApplyUpgrades1();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BigMeteor"))
        {
            ShipHealth -= 25;
            Destroy(collision.gameObject);
            Debug.Log("Ship Health -25 New Health = " + ShipHealth);
        }
        else if (collision.CompareTag("EnemyBullets"))
        {
            ShipHealth -= 20;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Meteor"))
        {
            ShipHealth -= 15;
            Destroy(collision.gameObject);
            Debug.Log("Ship Health -15 New Health = " + ShipHealth);
        }
        else if (collision.CompareTag("Enemy"))
        {
            ShipHealth -= 30;
            Destroy(collision.gameObject);
            Debug.Log("Ship Health -30 New Health = " + ShipHealth);
        }
    }

    public void ApplyUpgrades1()
    {
        if (upgradeManager != null)
        {
            upgradeManager.ApplyUpgrades1(this);
        }
    }
}
