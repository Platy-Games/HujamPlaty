using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    // Start is called before the first frame update
    public int CurrentHealth { get; set; }
    void Start()
    {
        CurrentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
