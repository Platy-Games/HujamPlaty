using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{
    private int ShipHealth = 100;
    // TODO: On collision with respective object, the object such as meteors do not respawn.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BigMeteor"))
        {
            ShipHealth -= 25;
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
    /*if (other.CompareTag("EnemyBullets"))
    {
        ShipHealth -= 20;
        Destroy(other.gameObject);
    }*/
}
