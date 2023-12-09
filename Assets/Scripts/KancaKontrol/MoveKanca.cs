using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKanca : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var inputMouse = Input.mousePosition;
        inputMouse = Camera.main.ScreenToWorldPoint(inputMouse);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, inputMouse - transform.position);

    }
}
