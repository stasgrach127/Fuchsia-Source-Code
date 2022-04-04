using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePickup : MonoBehaviour
{
    RogueLikeGenerator rlg;
    bool inZone;
    UIManager uiManager;
    MusicManager musManager;

    private void Start()
    {
        rlg = GameObject.FindObjectOfType<RogueLikeGenerator>();
        uiManager = GameObject.FindObjectOfType<UIManager>();
        musManager = GameObject.FindObjectOfType<MusicManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inZone)
        {
            int moneyReceived = Random.Range(5, 15);
            PlayerPrefs.SetInt("ReceivedMoney", PlayerPrefs.GetInt("ReceivedMoney") + moneyReceived);
            Debug.Log(PlayerPrefs.GetInt("ReceivedMoney"));
            uiManager.MoneyAddText(moneyReceived);
            uiManager.SetMoneyText();
            musManager.PlaySound("coin");
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
