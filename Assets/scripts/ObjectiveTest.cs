using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;

public class ObjectiveTest : Objective
{
    public float countdown = 5.0f;
    public string info = "Visit the Shrine";

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        countdown -= Time.deltaTime;
    }

    public override bool Achieved()
    {
        return (countdown < 0);
    }
    public override string message()
    {
        return (info);
    }

    public override void complete()
    {
        GameController.Instance.money += 100;
    }
}
