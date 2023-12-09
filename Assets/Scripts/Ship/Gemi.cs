using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemi : MonoBehaviour
{
    public int ShipHealth = 100;

    void Start()
    {
        DamageTaken.DamageEvent += HandleDamageTaken;
    }
    void HandleDamageTaken(int damageAmount)
    {
        ShipHealth -= damageAmount;
        Debug.Log("Hasar Alındı: " + damageAmount);
    }
}
