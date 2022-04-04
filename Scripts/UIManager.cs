using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //[SerializeField] string curScene;
    Canvas sceneUI;

    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text timeAddText;
    [SerializeField] TMP_Text moneyText;
    [SerializeField] TMP_Text moneyAddText;
    [SerializeField] TMP_Text informationText;

    private void Start()
    {
        ChangeChamberTimer(PlayerPrefs.GetFloat("MaxTime"));
        timeAddText.gameObject.SetActive(false);
        moneyAddText.gameObject.SetActive(false);
        informationText.gameObject.SetActive(false);
    }

    public void TimeAddText(float number)
    {
        timeAddText.gameObject.SetActive(false);
        timeAddText.gameObject.SetActive(true);
        timeAddText.text = "+" + number.ToString();
    }

    public void MoneyAddText(float number)
    {
        moneyAddText.gameObject.SetActive(false);
        moneyAddText.gameObject.SetActive(true);
        moneyAddText.text = "+" + number.ToString();
    }

    public void SetMoneyText()
    {
        moneyText.text = PlayerPrefs.GetInt("ReceivedMoney").ToString();
    }

    public void InformationUpdate(string infoText)
    {
        informationText.gameObject.SetActive(false);
        informationText.gameObject.SetActive(true);
        informationText.text = infoText;
    }

    public void ChangeChamberTimer(float curTime)
    {
        float minutes = Mathf.FloorToInt(curTime / 60);
        float seconds = Mathf.FloorToInt(curTime % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void CheckMoneyAmount()
    {
        if (PlayerPrefs.GetInt("ReceivedMoney") <= 0)
        {
            moneyText.text = "0";
            PlayerPrefs.SetInt("ReceivedMoney", 0);
        }
    }
}
