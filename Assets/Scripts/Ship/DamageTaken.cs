using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{
    [SerializeField] private GameObject BigMeteor;
    [SerializeField] private GameObject Meteor;
    [SerializeField] private GameObject EnemyBullets;
    [SerializeField] private GameObject Enemy;

    private int ShipHealth = 100;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BigMeteor"))
        {
            ShipHealth -= 50;
            Destroy(BigMeteor);
        }
        if (other.CompareTag("Meteor"))
        {
            ShipHealth -= 15;
            Destroy(Meteor);
            Debug.Log("Ship Healt -15." + ShipHealth);
        }
        if (other.CompareTag("Enemy"))
        {
            ShipHealth -= 30;
            Destroy(Enemy);
        }
        if (other.CompareTag("EnemyBullets"))
        {
            ShipHealth -= 20;
            Destroy(EnemyBullets);
        }
    }
}
