using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernQuest1 : Objective
{

    public string info = "Talk to Tertius Cordus in the Tavern";
    public int reward = 2;

    public int id = 27;
    public void Awake()
    {
        QuestDialogues dialogueStore = FindObjectOfType<QuestDialogues>();
        DontDestroyOnLoad(this);
    }
    public override bool Achieved()
    {
        if (FindObjectOfType<DialogueManger>().currentNPC == "Tertius Cordus")
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
        Player.Instance.addMoney(reward);

        knowledge.Encyclopedia.Instance.unlockEntry(id);
        //FindObjectOfType<EcycloUIManager>().updateUI();

        if (!Player.Instance.gameObject.GetComponent<TavernQuest2>())
        {
            Player.Instance.gameObject.AddComponent<TavernQuest2>();
        }
    }
}
