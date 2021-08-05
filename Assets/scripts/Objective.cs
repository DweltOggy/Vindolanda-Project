using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objective : MonoBehaviour
{
    public abstract bool Achieved();
    public abstract string message();
    public abstract void complete();
}

