using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathHouseQuest2 : Objective
{
    public string info = "Buy some Supplies for Manius from the Market!";
    public int reward = 2;

    public override bool Achieved()
    {
        bool done = false;

        if (FindObjectOfType<DialogueManger>().currentNPC != "Manius Rex"
            && Player.Instance.playerInventory.checkInventory("SHOP_MEAT"))
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
        if (!Player.Instance.gameObject.GetComponent<BathHouseQuest3>())
        {
            Player.Instance.gameObject.AddComponent<BathHouseQuest3>();
        }
    }
}
