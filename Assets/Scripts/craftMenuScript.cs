using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;
using TMPro;

public class craftMenuScript : MonoBehaviour
{
    GameObject weaponPanel;
    GameObject armorPanel;
    GameObject hookPanel;
    GameObject speedPanel;
    /*---------------------*/
    public Button weaponUpButton;
    public Button armorUpButton;
    public Button hookUpButton;
    public Button speedUpButton;
    /*---------------------*/
    int weaponUpCounter = 0;
    int armorUpCounter = 0;
    int speedUpCounter = 0;
    int hookUpCounter = 0;
    /*---------------------*/
    TextMeshProUGUI weaponMax;
    public GameObject weaponMaxObj;
    TextMeshProUGUI armorMax;
    public GameObject armorMaxObj;
    TextMeshProUGUI hookMax;
    public GameObject hookMaxObj;
    TextMeshProUGUI speedMax;
    public GameObject speedMaxObj;
    /*---------------------*/
    void Start()
    {
        weaponUpButton.onClick.AddListener(weaponUPOnClick);
        armorUpButton.onClick.AddListener(armorUPOnClick);
        hookUpButton.onClick.AddListener(hookUPOnClick);
        speedUpButton.onClick.AddListener(speedUPOnClick);

        weaponPanel = GameObject.FindGameObjectWithTag("weaponPanel");
        armorPanel = GameObject.FindGameObjectWithTag("armorPanel");
        hookPanel = GameObject.FindGameObjectWithTag("hookPanel");
        speedPanel = GameObject.FindGameObjectWithTag("speedPanel");

    }
    void weaponUPOnClick()
    {
        weaponPanel.transform.GetChild(weaponUpCounter).gameObject.SetActive(true);
        weaponUpCounter++;
        if (weaponUpCounter == 4) 
        { 
            weaponUpButton.interactable = false;
            weaponMaxObj.SetActive(true);
        }
    }
    void armorUPOnClick()
    {
        armorPanel.transform.GetChild(armorUpCounter).gameObject.SetActive(true);
        armorUpCounter++;
        if (armorUpCounter == 4)
        {
            armorUpButton.interactable = false;
            armorMaxObj.SetActive(true);
        }
    }
    void speedUPOnClick()
    {
        speedPanel.transform.GetChild(speedUpCounter).gameObject.SetActive(true);
        speedUpCounter++;
        if (speedUpCounter == 4)
        {
            speedUpButton.interactable = false;
            speedMaxObj.SetActive(true);
        }
    }
    void hookUPOnClick()
    {
        hookPanel.transform.GetChild(hookUpCounter).gameObject.SetActive(true);
        hookUpCounter++;
        if (hookUpCounter == 4)
        {
            hookUpButton.interactable = false;
            hookMaxObj.SetActive(true);
        }
    }

}
