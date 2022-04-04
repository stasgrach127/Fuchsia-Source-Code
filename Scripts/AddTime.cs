using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddTime : MonoBehaviour
{
    bool inZone;
    GameObject textPopup;
    [SerializeField] TMP_Text moneyText;

    private void Start()
    {
        textPopup = transform.GetChild(0).gameObject;
        textPopup.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inZone)
        {
            UpgradeTime();
        }
    }

    void UpgradeTime()
    {
        if (PlayerPrefs.GetInt("Money") >= PlayerPrefs.GetInt("UpgradePrice"))
        {
            PlayerPrefs.SetInt("Money", (PlayerPrefs.GetInt("Money") - PlayerPrefs.GetInt("UpgradePrice")));
            PlayerPrefs.SetInt("UpgradePrice", PlayerPrefs.GetInt("UpgradePrice") + 25);
            PlayerPrefs.SetFloat("MaxTime", PlayerPrefs.GetFloat("MaxTime") + 10f);
            moneyText.text = (PlayerPrefs.GetInt("Money")).ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MC")
        {
            inZone = true;
            textPopup.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "MC")
        {
            inZone = false;
            textPopup.SetActive(false);
        }
    }
}
