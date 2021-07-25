using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class itemObject : ScriptableObject
{
    public new string name;
    public string description;
    public string objID;
    public int databaseEntry;
    //public Sprite image;

    public itemObject(string objID, string name, string desc, int data)
    {
        this.objID = objID;    
        this.name = name;
        this.description = desc;
        this.databaseEntry = data;
    }
    
}
