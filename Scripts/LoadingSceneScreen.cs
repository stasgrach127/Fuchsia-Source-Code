using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneScreen : MonoBehaviour
{
    public string sceneToLoad;
    [SerializeField] GameObject continueText;
    AsyncOperation curOperation;

    private void Start()
    {
        continueText.SetActive(false);
        NewScene();
    }

    void NewScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
