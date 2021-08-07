using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainQuest : Objective
{
    public string info = "Buy the Perfect Birthday Gift!";
    public int reward = 2;

    public override bool Achieved()
    {
        return Player.Instance.playerInventory.checkInventory("QUEST_COMB");
    }
    public override string message()
    {
        return (info);
    }

    public override void complete()
    {
        objectives.GameController.Instance.endGame();
    }
}
