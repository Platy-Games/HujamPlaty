using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private Animator _animator;
    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(_animator.GetCurrentAnimatorStateInfo(0).length);
        if (_animator.GetCurrentAnimatorStateInfo(0).length <= _animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            if (SceneManager.GetActiveScene().name == "GameOverScene")
            {
                canvas.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
