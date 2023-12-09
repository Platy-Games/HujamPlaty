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
        }
        if (other.CompareTag("Meteor"))
        {
            ShipHealth -= 15;
            Debug.Log("Ship Healt -15." + ShipHealth);
        }
        if (other.CompareTag("Enemy"))
        {
            ShipHealth -= 30;
        }
        if (other.CompareTag("EnemyBullets"))
        {
            ShipHealth -= 20;
        }
    }
}
