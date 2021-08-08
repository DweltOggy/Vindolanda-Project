using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathHouseQuest1 : Objective
{
    public string info = "Talk to Manius Rex in the Bath House";
    public int reward = 2;

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public override bool Achieved()
    {
        if (FindObjectOfType<DialogueManger>().currentNPC == "Manius Rex")
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
        knowledge.Encyclopedia.Instance.unlockEntry(25);
        //FindObjectOfType<EcycloUIManager>().updateUI();
        if (!Player.Instance.gameObject.GetComponent<BathHouseQuest2>())
        {
            Player.Instance.gameObject.AddComponent<BathHouseQuest2>();
        }
    }
}
