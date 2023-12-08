using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserCont : MonoBehaviour
{
    enemyAttack dusman;
    Rigidbody2D fizik;
    // Start is called before the first frame update
    void Start()
    {
        dusman=GameObject.FindGameObjectWithTag("enemyShip").GetComponent<enemyAttack>();
        fizik=GetComponent<Rigidbody2D>();
        fizik.AddForce(dusman.getYon()*1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
