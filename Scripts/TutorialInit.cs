using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInit : MonoBehaviour
{
    [SerializeField] GameObject tutorial;

    private void Start()
    {
        tutorial.SetActive(false);
        Time.timeScale = 0f;
        tutorial.SetActive(true);
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            tutorial.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
