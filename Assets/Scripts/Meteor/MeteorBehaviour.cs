using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{
    private GameObject ganca;
    private void Start()
    {
        _isHooked = false;
        GANCA.HookedEvent.AddListener(Hooked);
        ganca = GameObject.Find("Hook");
    }

    private void Update()
    {
        if (_isHooked)
        {
            transform.position = Vector3.MoveTowards(transform.position, ganca.transform.position, 0.03f);
        }
    }

    private bool _isHooked;
    private void Hooked()
    {
        _isHooked = true;
    }
}
