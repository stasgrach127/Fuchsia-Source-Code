using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DialogueClass
{
    [Header("General")]
    public string dialogueClassSpeaker;
    [TextArea]
    public string dialogueClassText;
    public float dialogueTextSpeed = 0.03f;
}

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Game Objects/Dialogue")]
[System.Serializable]
public class DialogueObject : ScriptableObject
{
    public DialogueClass[] doClass;
}
