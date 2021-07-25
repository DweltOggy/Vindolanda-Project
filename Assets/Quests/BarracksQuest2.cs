using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;
using UnityEngine.SceneManagement;

public class BarracksQuest2 : Objective
{
    public string info = "Find Gaius' helemet!";
    public int reward = 2;

    public override bool Achieved()
    {
        return GameController.Instance.playerInventory.checkInventory("Quest_Helmet");
    }
    public override string message()
    {
        return (info);
    }

    public override void complete()
    {

        GameController.Instance.money += reward;
        if (!GameController.Instance.gameObject.GetComponent<BarracksQuest3>())
        {
            GameController.Instance.gameObject.AddComponent<BarracksQuest3>();
        }
    }
}
