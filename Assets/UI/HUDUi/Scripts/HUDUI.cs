using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDUI : MonoBehaviour
{
    [SerializeField] Button exitUIButton;

    void Start()
    {
        exitUIButton.onClick.RemoveAllListeners();
        exitUIButton.onClick.AddListener(Exit);
    }

    void Exit()
    {
        print("quitting");
        Application.Quit();
    }

    void changeScene()
    {
        SceneManager.LoadScene("Encyclopedia");
    }
}
