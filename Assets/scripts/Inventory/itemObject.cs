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
    public GameObject prefab;
    public int value = 10;

    public void set(string objID, string name, string desc, int data)
    {
        this.objID = objID;    
        this.name = name;
        this.description = desc;
        this.databaseEntry = data;
        if(prefab != null)
        {
            prefab.GetComponent<ToolTipTrigger>().header = name;
            prefab.GetComponent<ToolTipTrigger>().content = desc;
        }
    }
    public void setPrefab()
    {
        if (prefab != null)
        {
            prefab.GetComponent<ToolTipTrigger>().header = name;
            prefab.GetComponent<ToolTipTrigger>().content = description;
        }
    }
    

}
