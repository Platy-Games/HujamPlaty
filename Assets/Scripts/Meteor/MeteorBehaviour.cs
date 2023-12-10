using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{
    private GameObject ganca;

    private void Start()
    {
        // 1. Ganka Objesini Bul
        ganca = GameObject.Find("Hook");

        // 2. Ganka Var mı Kontrol Et
        if (ganca != null)
        {
            // 3. Ganka Bulunamazsa Hata Ver
            GANCA.HookedEvent.AddListener(Hooked);
        }
        else
        {
            Debug.LogError("GANCA objesi bulunamadı.");
        }

        // 4. İlk Durumu Ayarla
        _isHooked = false;
    }

    private void Update()
    {
        if (_isHooked)
        {
            // Ganka'ya doğru hareket et
            transform.position = Vector3.MoveTowards(transform.position, ganca.transform.position, 0.03f);
        }
    }

    private bool _isHooked;

    private void Hooked()
    {
        // Ganka yakalandığında _isHooked'i true yap
        _isHooked = true;
    }
}
