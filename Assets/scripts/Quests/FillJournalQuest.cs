using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using knowledge;

public class FillJournalQuest : Objective
{
    public string info = "Fill your journal!";
    public int reward = 200;

    public override bool Achieved()
    {
        bool complete = false;
        if(Encyclopedia.Instance.percentageComplete() == 100.0f)
            complete = true;
        return complete;
    }
    public override string message()
    {
        return (info);
    }

    public override void complete()
    {
        Player.Instance.addMoney(reward);
    }
}
