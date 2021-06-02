using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;

public class ObjectiveTest : Objective
{
    public override bool Achieved()
    {
        return false;
    }
    public override string message()
    {
        return ("Visit the Shrine");
    }
}
