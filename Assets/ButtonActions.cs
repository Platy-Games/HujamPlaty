using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public void OnPlayAgainButtonClicked()
    {
        string levelToLoad = DamageTaken.LevelName;
        SceneManager.MoveGameObjectToScene(GameObject.FindWithTag("Player"), SceneManager.GetActiveScene());
        SceneManager.LoadScene(levelToLoad);
    }
}
