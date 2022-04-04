using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WaitProgression : MonoBehaviour
{
    [SerializeField] GameObject portal;
    [SerializeField] TMP_Text moneyText;
    [SerializeField] TMP_Text timerText;
    [SerializeField] GameObject tutorialOne;
    [SerializeField] GameObject tutorialTwo;
    [SerializeField] GameObject menu;

    int progressionCheck;
    Dialogue dialogueSyst;

    [SerializeField] DialogueObject[] dialogues;

    private void Start()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        progressionCheck = PlayerPrefs.GetInt("VisitTime");
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + PlayerPrefs.GetInt("ReceivedMoney"));
        PlayerPrefs.SetInt("ReceivedMoney", 0);
        dialogueSyst = GameObject.FindObjectOfType<Dialogue>();
        SetupWaitingRoom();
    }

    void SetupWaitingRoom()
    {
        switch(progressionCheck)
        {
            case 0:
                moneyText.text = PlayerPrefs.GetInt("Money").ToString();
                timerText.text = "???";
                tutorialOne.SetActive(true);
                tutorialTwo.SetActive(false);
                PlayerPrefs.SetInt("Hours", 10);
                dialogueSyst.dialogueObject = dialogues[0];
                break;
            case 1:
                moneyText.text = PlayerPrefs.GetInt("Money").ToString();
                tutorialOne.SetActive(false);
                tutorialTwo.SetActive(true);
                dialogueSyst.dialogueObject = dialogues[1];
                timerText.text = PlayerPrefs.GetInt("Hours").ToString();
                break;
            case 2:
                moneyText.text = PlayerPrefs.GetInt("Money").ToString();
                tutorialOne.SetActive(false);
                tutorialTwo.SetActive(false);
                dialogueSyst.dialogueObject = dialogues[2];
                timerText.text = PlayerPrefs.GetInt("Hours").ToString();
                break;
            default:
                moneyText.text = PlayerPrefs.GetInt("Money").ToString();
                tutorialOne.SetActive(false);
                tutorialTwo.SetActive(false);
                dialogueSyst.dialogueObject = null;
                dialogueSyst.enabled = false;
                GameObject.Find("Dialogue Canvas").SetActive(false);
                timerText.text = PlayerPrefs.GetInt("Hours").ToString();
                break;
        }
        CheckHours();
    }

    void CheckHours()
    {
        if (PlayerPrefs.GetInt("Hours") <= 0)
        {
            SceneManager.LoadScene("game_over");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.000001f;
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }    
        if (Input.GetKeyDown(KeyCode.T) && PlayerPrefs.GetInt("Money") >= 40)
        {
            PlayerPrefs.SetInt("Money", (PlayerPrefs.GetInt("Money") - 40));
            PlayerPrefs.SetInt("Hours", PlayerPrefs.GetInt("Hours") + 1);
            moneyText.text = (PlayerPrefs.GetInt("Money")).ToString();
            timerText.text = PlayerPrefs.GetInt("Hours").ToString();
        }
    }

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("main_menu");
    }
}
