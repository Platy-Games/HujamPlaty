using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonMusic : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
            Destroy(gameObject);
        }
    }
}
