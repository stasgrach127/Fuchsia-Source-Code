using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        ResetData();
        SceneManager.LoadSceneAsync("first_cutscene");
    }

    public void ContinueGame()
    {
        PlayerPrefs.SetInt("ReceivedMoney", 0);
        SceneManager.LoadSceneAsync("waiting_room");
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    void ResetData()
    {
        PlayerPrefs.SetInt("ReceivedMoney", 0);
        PlayerPrefs.SetInt("VisitTime", 0);
        PlayerPrefs.SetInt("Money", 0);
        PlayerPrefs.SetInt("Hours", 0);
        PlayerPrefs.SetInt("SecondChamber", 0);
        PlayerPrefs.SetFloat("MaxTime", 30f);
        PlayerPrefs.SetInt("UpgradePrice", 50);
        PlayerPrefs.SetInt("WeaponUpgrade", 0);
    }
}
