using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            Invoke("OpenCanvas", 1.5f);
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            canvas.SetActive(false);
        }
    
        if (Input.GetKeyDown(KeyCode.D))
        {
            Invoke("OpenCanvas1", 1.5f);
        }
        else if(Input.GetKeyUp(KeyCode.D))
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
