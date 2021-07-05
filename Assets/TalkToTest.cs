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
        DontDestroyOnLoad(this.gameObject);
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
        
        GameController.Instance.money += reward;
    }
}
