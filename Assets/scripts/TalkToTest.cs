using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;
public class TalkToTest : Objective
{
    public string info = "Talk to the Bar Keeper";
    public int reward = 100;
    public void Awake()
    {
       
    }
    public override bool Achieved()
    {
        if (FindObjectOfType<DialogueManger>().currentNPC == "Bar Keeper")
        {
            return true;
        }
        return false;
    }
    public override string message()
    {
        return (info);
    }

    public override void complete()
    {
        Player.Instance.money += reward;
    }
}
