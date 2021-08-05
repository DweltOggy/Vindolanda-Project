using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuestionCollection : ScriptableObject
{
    public List<Question> questions;
    public bool complete = false;
}
