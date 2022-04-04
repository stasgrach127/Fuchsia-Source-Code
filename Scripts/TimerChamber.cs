using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerChamber : MonoBehaviour
{
    float maxChamberTime;
    public  float curChamberTime;
    UIManager uiManager;
    MusicManager musManager;

    private void Start()
    {
        PlayerPrefs.SetInt("VisitTime", PlayerPrefs.GetInt("VisitTime") + 1);
        maxChamberTime = PlayerPrefs.GetFloat("MaxTime");
        curChamberTime = maxChamberTime;
        uiManager = GameObject.FindObjectOfType<UIManager>();
        musManager = GameObject.FindObjectOfType<MusicManager>();
        StartCoroutine("ChangeTime");
    }

    public void AddTime(float amount)
    {
        curChamberTime += amount;
    }

    IEnumerator ChangeTime()
    {
        yield return new WaitForSeconds(1f);
        curChamberTime--;
        uiManager.ChangeChamberTimer(curChamberTime);
        if (curChamberTime <= 0)
        {
            GameOverChamber();
        }    
        else
        {
            StartCoroutine("ChangeTime");
        }
    }

    void GameOverChamber()
    {
        musManager.PlaySound("gameover");   
        StartCoroutine("GoToWait");
    }

    IEnumerator GoToWait()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("waiting_room");
    }
}
