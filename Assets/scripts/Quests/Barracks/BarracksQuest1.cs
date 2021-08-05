using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksQuest1 : Objective
{
    public string info = "Talk to Gaius Marinus in the Barracks";
    public int reward = 2;

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public override bool Achieved()
    {
        if (/*FindObjectOfType<DialogueManger>().inDialogue == false &&*/
            FindObjectOfType<DialogueManger>().currentNPC == "Gaius Marinus")
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
        knowledge.Encyclopedia.Instance.unlockEntry(22);
        FindObjectOfType<EcycloUIManager>().updateUI();
        if (!Player.Instance.gameObject.GetComponent<BarracksQuest2>())
        {
            Player.Instance.gameObject.AddComponent<BarracksQuest2>();
        }
    }
}
