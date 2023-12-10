using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public float damageupgrade;
    public float speedupgrade;
    public int healthupgrade;
    public void ApplyUpgrades(bulletScript bulletScript)
    {
        bulletScript.bulletStrength += damageupgrade;
        bulletScript.speed += speedupgrade;
    }
    public void ApplyUpgrades1(DamageTaken damagetaken)
    {
        damagetaken.ShipHealth += healthupgrade;
    }
}
