using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangeDevice : MonoBehaviour
{
    RogueLikeGenerator rlg;
    bool inZone;
    UIManager uiManager;
    MusicManager musManager;
    TimerChamber tChamber;

    private void Start()
    {
        uiManager = GameObject.FindObjectOfType<UIManager>();
        musManager = GameObject.FindObjectOfType<MusicManager>();
        tChamber = GameObject.FindObjectOfType<TimerChamber>();
    }

    private void Update()
    {
        this.transform.Rotate(new Vector3(0, 0.3f, 0) * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.E) && inZone)
        {
            int chanceProc = Random.Range(1, 100);
            if (chanceProc >= 80)
            {
                int addingTime = Random.Range(10, 21);
                tChamber.AddTime(addingTime);
                uiManager.ChangeChamberTimer(tChamber.curChamberTime);
                uiManager.TimeAddText(addingTime);
                musManager.PlaySound("clock");
            }
            Destroy(this.gameObject);
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
