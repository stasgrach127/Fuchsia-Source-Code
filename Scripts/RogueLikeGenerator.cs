using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RogueLikeGenerator : MonoBehaviour
{
    UIManager uiManager;
    MusicManager musManager;
    [SerializeField] Transform startRoom;
    [SerializeField] List<Transform> generatedRooms;
    [SerializeField] int variantAmount;
    public int roomsCompleted;

    [SerializeField] Transform[] easyEnemies;
    [SerializeField] Transform[] middleEnemies;
    [SerializeField] Transform[] hardEnemies;

    [SerializeField] Transform tablePrefab;
    [SerializeField] Transform cubeGuess;
    [SerializeField] Transform strangeDevice;
    [SerializeField] Transform keyHolder;
    [SerializeField] Transform bookNote;

    public GameObject notebook;
    public TMP_Text notebookText;

    private void Start()
    {
        notebook.SetActive(false);
        Transform firstRoom = Instantiate(startRoom);
        firstRoom.name = "genRoom 0";
        generatedRooms = new List<Transform>();
        generatedRooms.Add(firstRoom);
        uiManager = GameObject.FindObjectOfType<UIManager>();
        musManager = GameObject.FindObjectOfType<MusicManager>();
        PlayerPrefs.SetInt("Hours", PlayerPrefs.GetInt("Hours") - 2);
    }

    public void ReturnCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public Transform GenerateRoom(Transform prefab, Transform position)
    {
        Transform room = Instantiate(prefab, position.position, prefab.rotation);
        generatedRooms.Add(room);
        roomsCompleted++;
        room.name = "genRoom " + generatedRooms.Count;
        if (generatedRooms.Count >= 4) Destroy(generatedRooms[generatedRooms.Count - 4].gameObject);
        return room;
    }

    public void SetupRoutes(Transform curRoom)
    {

    }

    public void SetupRoom(Transform curRoom)
    {
        int roomType = new int();
        roomType = Random.Range(1, variantAmount);
        if (roomType == 1)
        {
            musManager.PlaySound("danger");
        }
        else
        {
            musManager.PlaySound("portal");
        }
        switch (roomType)
        {
            case 1:
                Transform[] transformEnemy = CheckDifficultyLevelEnemies();
                for (int j = 0; j < Random.Range(1, 3); j++)
                {
                    Transform tra = Instantiate(transformEnemy[Random.Range(0, transformEnemy.Length)], curRoom.GetChild(curRoom.transform.childCount - 1).GetChild(Random.Range(0, 2)));
                    tra.localPosition = new Vector3(0f, 0f, 0f);
                }
                uiManager.InformationUpdate("Enemy encounter!");
                break;
            case 2:
                Transform strangeMachine = Instantiate(strangeDevice, curRoom.GetChild(curRoom.transform.childCount - 1).GetChild(Random.Range(0, 2)));
                strangeMachine.localPosition = new Vector3(0f, 0f, 0f);
                uiManager.InformationUpdate("Strange machine...");
                break;
            case 3:
                Transform tabletra = Instantiate(tablePrefab, curRoom.GetChild(curRoom.transform.childCount - 1).GetChild(Random.Range(0, 2)));
                tabletra.localPosition = new Vector3(0f, 0f, 0f);
                uiManager.InformationUpdate("Free money!");
                break;
            case 4:
                Transform cubeGuessPref = Instantiate(cubeGuess, curRoom.GetChild(curRoom.transform.childCount - 1).GetChild(Random.Range(0, 2)));
                cubeGuessPref.localPosition = new Vector3(0f, 0f, 0f);
                uiManager.InformationUpdate("Guess the right cube!");
                break;
            case 5:
                uiManager.InformationUpdate("Complete emptiness...");
                break;
            case 6:
                Transform keyHolderPref = Instantiate(keyHolder, curRoom.GetChild(curRoom.transform.childCount - 1).GetChild(Random.Range(0, 2)));
                keyHolderPref.localPosition = new Vector3(0f, 0f, 0f);
                uiManager.InformationUpdate("Machine that holds the key.");
                break;
            case 7:
                Transform notebook = Instantiate(bookNote, curRoom.GetChild(curRoom.transform.childCount - 1).GetChild(Random.Range(0, 2)));
                notebook.localPosition = new Vector3(0f, 0f, 0f);
                uiManager.InformationUpdate("Memories of the past.");
                break;
        }
        roomType = 0;
    }

    public Transform[] CheckDifficultyLevelEnemies()
    {
        if (roomsCompleted >= 20 && roomsCompleted <= 40) return middleEnemies;
        else if (roomsCompleted >= 41) return hardEnemies;
        else return easyEnemies;
    }
}
