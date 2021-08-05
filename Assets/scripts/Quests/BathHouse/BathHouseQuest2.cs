using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathHouseQuest2 : Objective
{
    public string info = "Buy some Supplies for Manius from the Market!";
    public int reward = 2;

    public override bool Achieved()
    {
        return Player.Instance.playerInventory.checkInventory("SHOP_MEAT");
    }
    public override string message()
    {
        return (info);
    }

    public override void complete()
    {
        Player.Instance.money += reward;
        if (!Player.Instance.gameObject.GetComponent<BathHouseQuest3>())
        {
            Player.Instance.gameObject.AddComponent<BathHouseQuest3>();
        }
    }
}
