using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotebookOpen : MonoBehaviour
{
    bool inZone;
    RogueLikeGenerator rgl;
    [TextArea]
    [SerializeField] string[] textNotebook;

    private void Start()
    {
        rgl = GameObject.FindObjectOfType<RogueLikeGenerator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inZone)
        {
            {
                OpenBook();
                Destroy(this.gameObject);
            }
        }
    }

    void OpenBook()
    {
        Cursor.lockState = CursorLockMode.None;
        rgl.notebook.SetActive(true);
        rgl.notebookText.text = textNotebook[Random.Range(0, textNotebook.Length)];
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
