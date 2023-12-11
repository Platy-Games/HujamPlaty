using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{
    private GameObject _ganca;

    private void Start()
    {
        // 1. Ganka Objesini Bul
        _ganca = GameObject.Find("Hook");

        // 2. Ganka Var mı Kontrol Et

        // 4. İlk Durumu Ayarla
        _isHooked = false;
    }

    private void Update()
    {
        if (_isHooked)
        {
            // Ganka'ya doğru hareket et
            transform.Translate(Vector3.zero, _ganca.transform);
        }
    }

    private bool _isHooked;

    private void Hooked()
    {
        // Ganka yakalandığında _isHooked'i true yap
        _isHooked = true;
    }
}
