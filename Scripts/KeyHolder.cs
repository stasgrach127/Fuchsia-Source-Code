using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    bool inZone;

    private void Update()
    {
        this.transform.Rotate(new Vector3(0, 0.1f, 0) * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.E) && inZone)
        {
            if (PlayerPrefs.GetInt("Money") == 1000)
            {
                PlayerPrefs.SetInt("SecondChamber", 1);
                Destroy(this.gameObject);
            }
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
