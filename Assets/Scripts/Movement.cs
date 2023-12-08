using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject canvas1;

    private void Start()
    {
        canvas.SetActive(false);
        canvas1.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Invoke("OpenCanvas", 1.5f);
        }
        else
        {
            canvas.SetActive(false);
        }
    
        if (Input.GetKey(KeyCode.D))
        {
            Invoke("OpenCanvas1", 1.5f);
        }
        else
        {
            canvas1.SetActive(false);
        }
    }


    private void OpenCanvas()
    {
        canvas.SetActive(true);
    }

    private void OpenCanvas1()
    {
        canvas1.SetActive(true);
    }
}
