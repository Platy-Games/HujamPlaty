using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    private void Start()
    {
        canvas.SetActive(false);
    }

    private void Update()
    {
        {
            Invoke("OpenCanvas", 1.5f);
            Debug.Log("Çalışşşş köle");
        }
        else
        {
            canvas.SetActive(false);
        }
    }

    private void OpenCanvas()
    {
        canvas.SetActive(true);
    }
}
