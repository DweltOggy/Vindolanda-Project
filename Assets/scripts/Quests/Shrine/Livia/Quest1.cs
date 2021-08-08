using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;

public class Quest1  : Objective
{

    public string info = "Talk to Livia Pola in the Temple";
    public int reward = 2;
    public itemObject delivery;

    public void Awake()
    {
        QuestDialogues dialogueStore = FindObjectOfType<QuestDialogues>();

        delivery = dialogueStore.pendant;

        DontDestroyOnLoad(this);
    }
    public override bool Achieved()
    {
        if (FindObjectOfType<DialogueManger>().currentNPC == "Livia Pola")
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
        Player.Instance.addItem(delivery);
        knowledge.Encyclopedia.Instance.unlockEntry(23);
        //FindObjectOfType<EcycloUIManager>().updateUI();
        knowledge.Encyclopedia.Instance.unlockEntry(delivery.databaseEntry);
        //FindObjectOfType<EcycloUIManager>().updateUI();

        Player.Instance.addMoney(reward);
        if (!Player.Instance.gameObject.GetComponent<Quest2>())
        {
            Player.Instance.gameObject.AddComponent<Quest2>();
        }
    }
}
