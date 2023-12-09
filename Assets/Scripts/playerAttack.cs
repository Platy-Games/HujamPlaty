using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPos;
    private Animator animator;

    private void Start()
    {
        animator.GetComponent<Animator>();
        float fire = 0f;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateABullet();
            float fire = 1f;
            animator.SetFloat("Fire", fire);
            
        }
    }
    void CreateABullet()
    {
        GameObject instance = Instantiate(bulletPrefab, spawnPos.position, Quaternion.identity);
        float fire = 3f;
        animator.SetFloat("Fire", fire);
    }
}
