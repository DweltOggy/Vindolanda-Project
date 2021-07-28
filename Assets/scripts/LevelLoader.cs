using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;

    public GameObject loadingScreen;
    public Slider loadingBar;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void loadLevel(string name)
    {
        StartCoroutine(LoadAsync(name));
    }

    public void exitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    IEnumerator LoadAsync (string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        loadingScreen.SetActive(true);
        
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.value = progress;
            yield return null;
        }
        loadingScreen.SetActive(false);
    }
}
