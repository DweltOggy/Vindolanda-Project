using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        LevelLoader.Instance.loadLevel("Opening");
    }

    public void loadMap()
    {
        LevelLoader.Instance.loadLevel("MapScene");
    }

    public void exitGame()
    {
        LevelLoader.Instance.exitGame();
    }
}
