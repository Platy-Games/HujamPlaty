using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{
    public delegate void OnDamageTaken(int damageAmount);
    public static event OnDamageTaken DamageEvent;

    [SerializeField] private GameObject BigMeteor;
    [SerializeField] private GameObject Meteor;
    [SerializeField] private GameObject EnemyBullets;
    [SerializeField] private GameObject Enemy;

    public int DamegeAmaunt;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BigMeteor"))
        {
            DamageEvent?.Invoke(50);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Meteor"))
        {
            DamageEvent?.Invoke(15);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            DamageEvent?.Invoke(30);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("EnemyBullets"))
        {
            DamageEvent?.Invoke(20);
            Destroy(other.gameObject);
        }
    }
}
