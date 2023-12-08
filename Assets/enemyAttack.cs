using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    GameObject ship;
    RaycastHit2D ray;
    public LayerMask layermask;
    public GameObject laser;
    public float attackCooldown;
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("FuturisticShip");


    }

    void FixedUpdate()
    {
        beniGordumu();
        if (ray.collider!=null&&ray.collider.tag==("FuturisticShip"))
        {
            Debug.Log("gordu");
            atesEt();
        }
    }

    private void beniGordumu()
    {
        Vector3 rayCiz = ship.transform.position - transform.position;
        ray=Physics2D.Raycast(transform.position,rayCiz,15,layermask);
        Debug.DrawLine(transform.position, ray.point, Color.magenta);
    }
    private void atesEt()
    {
        attackCooldown += Time.deltaTime;
        if (attackCooldown>Random.Range(1,2))
        {
            GameObject temp = Instantiate(laser,transform.position,Quaternion.identity);
            Destroy(temp,2f);
            attackCooldown = 0;
        }
    }

    public Vector2 getYon()
    {
        return (ship.transform.position-transform.position).normalized;
    }
}
