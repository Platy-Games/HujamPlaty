using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{
    private int ShipHealth = 100;

    [SerializeField] private GameObject bigMeteorPrefab;
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private GameObject enemyPrefab;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BigMeteor"))
        {
            ShipHealth -= 25;
            Destroy(collision.gameObject);
            Debug.Log("Ship Health -25 New Health = " + ShipHealth);
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
    /*if (other.CompareTag("EnemyBullets"))
    {
        ShipHealth -= 20;
        Destroy(other.gameObject);
    }*/
}
