using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public int money = 30;
    public List<itemObject> items;// = new List<itemObject>();

    public void addItem(itemObject newItem)
    { 
        if(!checkInventory(newItem.objID))
        {
            items.Add(newItem);
        }
    }

    public void clearInventory()
    {
        items.Clear();
    }
    public bool checkInventory(string Id)
    {
        foreach (var item in items)
            if (item.objID == Id)
                return true;
        return false;
    }

}
