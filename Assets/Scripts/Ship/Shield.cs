using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    

    [SerializeField] private GameObject bigMeteorPrefab;
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject EnemyBulletsPrefab;

    private UpgradeManager upgradeManager;

    public int upgradeLevel = 0;

    public int ShieldHealth = 50; // Kalkanın maksimum canı
    public float rechargeTime = 5f; // Kalkanın yenilenme süresi
    public int currentHealth; // Kalkanın mevcut canı
    private SpriteRenderer spriteRenderer; // Kalkanın Sprite Renderer componenti
    private CapsuleCollider2D capsuleCollider2D;
    private bool isBroken; // Kalkanın kırık olma durumu

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Sprite Renderer componentini al
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        currentHealth = ShieldHealth; // Mevcut canı maksimum cana eşitle
        isBroken = false; // Kırık olma durumunu false yap
    }
    
    void Start()
    {
        upgradeManager = FindObjectOfType<UpgradeManager>();
        currentHealth = ShieldHealth; // Mevcut canı maksimum cana eşitle
        isBroken = false; // Kırık olma durumunu false yap
        ApplyUpgrades3();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BigMeteor"))
        {
            currentHealth -= 25; // Mevcut canı azalt
            Destroy(collision.gameObject);
            Debug.Log("Shield Health -25 New Health = " + currentHealth);
            ShieldDamage();
        }
        else if (collision.CompareTag("EnemyBullets"))
        {
            currentHealth -= 15; // Mevcut canı azalt
            Destroy(collision.gameObject);
            ShieldDamage();
        }
        else if (collision.CompareTag("Meteor"))
        {
            currentHealth -= 20; // Mevcut canı azalt
            Destroy(collision.gameObject);
            Debug.Log("Shield Health -15 New Health = " + currentHealth);
            ShieldDamage();
        }
        else if (collision.CompareTag("Enemy"))
        {
            currentHealth -= 50; // Mevcut canı azalt
            Destroy(collision.gameObject);
            Debug.Log("Shield Health -30 New Health = " + currentHealth);
            ShieldDamage();
        }
    }
    public void ShieldDamage()
    {
        if (!isBroken) // Eğer kalkan kırık değilse
        {
            
            if (currentHealth <= 0) // Eğer mevcut can sıfıra eşit veya küçükse
            {
                Break(); // Kalkanı kır
            }
        }
    }
    private void Break()
    {
        isBroken = true; // Kırık olma durumunu true yap
        spriteRenderer.enabled = false; // Sprite Renderer'ı pasif yap
        capsuleCollider2D.enabled = false;
        StartCoroutine(Recharge()); // Yenilenme Coroutine'ini başlat
    }

    private IEnumerator Recharge()
    {
        yield return new WaitForSeconds(rechargeTime); // Belirli bir süre bekle
        currentHealth = ShieldHealth; // Mevcut canı maksimum cana eşitle
        spriteRenderer.enabled = true; // Sprite Renderer'ı aktif yap
        capsuleCollider2D.enabled = true;
        isBroken = false; // Kırık olma durumunu false yap
    }

    public void ApplyUpgrades3()
    {
        if (upgradeManager != null)
        {
            upgradeManager.ApplyUpgrades3(this);
        }
    }

}
