using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject options;
    GameObject start;
    GameObject help;
    GameObject title;
   
    private void Start()
    {
        options = GameObject.Find("options");
        start = GameObject.Find("start");
        title = GameObject.FindGameObjectWithTag("title");
        help=GameObject.Find("help");
        options.SetActive(false);
        start.SetActive(false);
        help.SetActive(false);

    }
    public void butonSec(int gelenButon)
    {
        if (gelenButon==1)
        {
            start.SetActive(true);
            title.SetActive(false);
            options.SetActive(false);
            help.SetActive(false);

        }
        else if (gelenButon == 2)
        {
            title.SetActive(false);
            options.SetActive(true);
            help.SetActive(false);
            start.SetActive(false);

        }
        else if (gelenButon == 3)
        {
            title.SetActive(false);
            help.SetActive(true);
            start.SetActive(false);
            options.SetActive(false);
        }
        else if (gelenButon == 4)
        {
            Application.Quit();
        }
        else if (gelenButon ==5)
        {
            title.SetActive(true);
            options.SetActive(false);
        }
        else if (gelenButon == 6)
        {
            //ses ac
        }
        else if (gelenButon == 7)
        {
            //ses kapa
        }
        if (gelenButon==8) 
        {
                SceneManager.LoadSceneAsync(2);
        }
        else if (gelenButon == 9)
        {
            SceneManager.LoadSceneAsync(1);
        }
        else if (gelenButon == 10)
        {
            title.SetActive(true);
            start.SetActive(false);
        }
        else if (gelenButon == 11)
        {
            title.SetActive(true);
            help.SetActive(false);
        }


    }
}
