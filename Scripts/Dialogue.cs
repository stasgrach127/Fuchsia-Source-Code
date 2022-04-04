using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    [Header("General")]
    public DialogueObject dialogueObject;
    bool isFinished;
    int count;
    bool canGo;
    public bool inDialogue;
    public bool isCutscene;

    public GameObject cutsceneTrigger0;
    public GameObject cutsceneTrigger1;

    [Header("UI")]
    GameObject dialogueCanvas;
    TMP_Text dialogueText;
    TMP_Text dialogueSpeaker;
    Image dialogueSpeakerImage;
    GameObject dialogueChoices;
    Slider dialogueSlider;

    private void Start()
    {
        canGo = true;
        isFinished = true;
        dialogueCanvas = GameObject.Find("Dialogue Canvas");
        dialogueText = dialogueCanvas.transform.GetChild(0).transform.GetChild(1).GetComponent<TMP_Text>();
        dialogueSpeaker = dialogueCanvas.transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>();

        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isFinished && count > 0)
            {
                StartDialogue();
            }
            else if (!canGo && !isFinished)
            {
                dialogueText.text = dialogueObject.doClass[count].dialogueClassText;
                isFinished = true;
            }
        }
    }

    public void StartDialogue()
    {
        dialogueCanvas.SetActive(true);
        NewPhrase();
    }

    public void EndDialogue()
    {
        count = 0;
        inDialogue = false;
    }

    public void ChangeDialogue(DialogueObject newDialogue)
    {
        StopCoroutine("WaitForAnswer");
        if (newDialogue != null)
        {
            dialogueObject = newDialogue;
            count = 0;
        }
        dialogueChoices.SetActive(false);
        dialogueSlider.gameObject.SetActive(false);
        NewPhrase();
    }

    void NewPhrase()
    {
        if (count != dialogueObject.doClass.Length)
        {
            if (cutsceneTrigger1 && count == 11)
            {
                cutsceneTrigger1.SetActive(true);
                cutsceneTrigger0.SetActive(false);
            }
            if (count == 18 && cutsceneTrigger1)
            {
                SceneManager.LoadScene("waiting_room");
            }
            inDialogue = true;
            isFinished = false;
            dialogueText.text = "";
            canGo = false;
            StartCoroutine("PlayText");
            dialogueSpeaker.text = dialogueObject.doClass[count].dialogueClassSpeaker;
        }
        else
        {
            EndDialogue();
            dialogueCanvas.SetActive(false);
        }
    }    

    IEnumerator PlayText()
    {
        foreach (char c in dialogueObject.doClass[count].dialogueClassText)
        {
            if (!isFinished)
            {
                dialogueText.text += c;
                yield return new WaitForSeconds(dialogueObject.doClass[count].dialogueTextSpeed);
            }
        }
        isFinished = true;
        count++;
    }
}
