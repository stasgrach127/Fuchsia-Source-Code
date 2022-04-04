using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwordUpgrade : MonoBehaviour
{
    bool inZone;
    GameObject textPopup;
    [SerializeField] TMP_Text moneyText;
    [SerializeField] WeaponScriptable[] weaScript;

    private void Start()
    {
        textPopup = transform.GetChild(0).gameObject;
        if (PlayerPrefs.GetInt("WeaponUpgrade") <= 3)
        {
            textPopup.GetComponent<TMP_Text>().text = "Upgrade cost: " + weaScript[PlayerPrefs.GetInt("WeaponUpgrade") + 1].wsPrice;
        }
        else
        {
            textPopup.GetComponent<TMP_Text>().text = "Can't upgrade.";
        }
        textPopup.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inZone)
        {
            UpgradeWeapon();
        }
    }

    void UpgradeWeapon()
    {
        if (PlayerPrefs.GetInt("WeaponUpgrade") <= 3)
        {
            if (PlayerPrefs.GetInt("Money") >= weaScript[PlayerPrefs.GetInt("WeaponUpgrade") + 1].wsPrice)
            {
                PlayerPrefs.SetInt("Money", (PlayerPrefs.GetInt("Money") - weaScript[PlayerPrefs.GetInt("WeaponUpgrade") + 1].wsPrice));
                PlayerPrefs.SetInt("WeaponUpgrade", PlayerPrefs.GetInt("WeaponUpgrade") + 1);
                moneyText.text = (PlayerPrefs.GetInt("Money")).ToString();
            }
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
