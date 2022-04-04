using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoChamber : MonoBehaviour
{
    bool inZone;
    GameObject firstChamberHelp;
    GameObject secondChamberHelp;

    private void Start()
    {
        firstChamberHelp = transform.GetChild(0).gameObject;
        secondChamberHelp = transform.GetChild(1).gameObject;
        firstChamberHelp.SetActive(false);
        secondChamberHelp.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inZone)
        {
            SceneManager.LoadScene("first_chamber");
        }
        if (Input.GetKeyDown(KeyCode.R) && inZone && PlayerPrefs.GetInt("SecondChamber") == 1)
        {
            SceneManager.LoadScene("second_chamber");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MC")
        {
            inZone = true;
            firstChamberHelp.SetActive(true);
            if (PlayerPrefs.GetInt("SecondChamber") == 1)
            {
                secondChamberHelp.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "MC")
        {
            inZone = false;
            firstChamberHelp.SetActive(false);
            secondChamberHelp.SetActive(false);
        }
    }
}
