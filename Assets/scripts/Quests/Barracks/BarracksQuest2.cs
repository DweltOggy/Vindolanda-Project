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
        bool done = false;
        
        if(FindObjectOfType<DialogueManger>().currentNPC != "Gaius Marinus" 
            && Player.Instance.playerInventory.checkInventory("Quest_Helmet"))
        {
            done = true;
        }

        return done;
    }
    public override string message()
    {
        return (info);
    }

    public override void complete()
    {

        Player.Instance.addMoney(reward);
        if (!Player.Instance.gameObject.GetComponent<BarracksQuest3>())
        {
            Player.Instance.gameObject.AddComponent<BarracksQuest3>();
        }
    }
}
