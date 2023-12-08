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
        if(Input.GetKey(KeyCode.A))
        {
            canvas.SetActive(true);
            Debug.Log("Çalışsana amk");
        }
    
        else
        {
            canvas.SetActive(false);
        }
    }
    
}
