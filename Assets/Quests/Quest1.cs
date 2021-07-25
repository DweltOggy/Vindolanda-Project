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
        delivery = new itemObject("Quest_Pendant",
                            "Livia's Pendant",
                            "Livia Asked you to deliver this!",
                            0);

        DontDestroyOnLoad(this);
    }
    public override bool Achieved()
    {
        if (/*FindObjectOfType<DialogueManger>().inDialogue == false &&*/
            FindObjectOfType<DialogueManger>().currentNPC == "Livia Pola")
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
        GameController.Instance.addItem(delivery);
        GameController.Instance.money += reward;
        if(!GameController.Instance.gameObject.GetComponent<Quest2>())
        {
            GameController.Instance.gameObject.AddComponent<Quest2>();
        }
    }
}
