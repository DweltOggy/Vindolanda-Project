using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] GameObject endCanvas;
    public void hide()
    {
        endCanvas.SetActive(false);
    }

    public void restart()
    {
        Player.Instance.restart();
        knowledge.Encyclopedia.Instance.restart();
        objectives.GameController.Instance.restart();

        ShopButtons test = GameObject.FindObjectOfType<ShopButtons>();
        if (test)
        {
            test.populate();
            test.gameObject.SetActive(false);
        }

        GameObject[] invPrefabs = GameObject.FindGameObjectsWithTag("InvPrefab");
        foreach(var prefab in invPrefabs)
        {
            Destroy(prefab);
        }
        objectives.GameController.Instance.restart();
        endCanvas.SetActive(false);
        LevelLoader.Instance.loadLevel("StartScene");
    }

}
