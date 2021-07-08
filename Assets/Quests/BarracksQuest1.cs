using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;
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
        GameController.Instance.money += reward;
        if (!GameController.Instance.gameObject.GetComponent<BarracksQuest2>())
        {
            GameController.Instance.gameObject.AddComponent<BarracksQuest2>();
        }
    }
}
