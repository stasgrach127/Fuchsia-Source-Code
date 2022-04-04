using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGuess : MonoBehaviour
{
    bool inZone;
    TimerChamber tChamber;
    UIManager uiManager;
    MusicManager musManager;

    private void Start()
    {
        tChamber = GameObject.FindObjectOfType<TimerChamber>();
        uiManager = GameObject.FindObjectOfType<UIManager>();
        musManager = GameObject.FindObjectOfType<MusicManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inZone)
        {
            int guess = Random.Range(0, 2);
            int prize = Random.Range(0, 2);
            if (guess == 0)
            {
                if (prize == 0)
                {
                    tChamber.AddTime(10f);
                    uiManager.TimeAddText(10f);
                    uiManager.ChangeChamberTimer(10f);
                    musManager.PlaySound("clock");
                }
                if (prize == 1)
                {
                    PlayerPrefs.SetInt("ReceivedMoney", PlayerPrefs.GetInt("ReceivedMoney") + 30);
                    uiManager.MoneyAddText(30);
                    uiManager.SetMoneyText();
                    musManager.PlaySound("coin");
                }
            }
            else
            {
                if (prize == 0)
                {
                    tChamber.AddTime(-10f);
                    uiManager.ChangeChamberTimer(-10f);
                }
                if (prize == 1)
                {
                    PlayerPrefs.SetInt("ReceivedMoney", PlayerPrefs.GetInt("ReceivedMoney") - 30);
                    uiManager.MoneyAddText(-30);
                    uiManager.SetMoneyText();
                }
            }

            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MC")
        {
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "MC")
        {
            inZone = false;
        }
    }
}
