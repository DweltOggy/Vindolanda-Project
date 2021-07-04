using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;
public class CollectionTest : Objective
{
    public string info = "Find the Helmet";
    public int reward = 100;
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public override bool Achieved()
    {
        return GameController.Instance.checkInventory("Helmet");
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
