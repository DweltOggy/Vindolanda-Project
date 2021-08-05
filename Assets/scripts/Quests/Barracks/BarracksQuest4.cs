using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;

public class BarracksQuest4 : Objective
{
    public string info = "Find Gaius' Bow!";
    public int reward = 2;

    public override bool Achieved()
    {
        return Player.Instance.playerInventory.checkInventory("Quest_Bow");
    }
    public override string message()
    {
        return (info);
    }

    public override void complete()
    {

        Player.Instance.money += reward;
        if (!Player.Instance.gameObject.GetComponent<BarracksQuest5>())
        {
            Player.Instance.gameObject.AddComponent<BarracksQuest5>();
        }
    }
}
