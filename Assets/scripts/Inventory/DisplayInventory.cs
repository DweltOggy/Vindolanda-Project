using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public Inventory inventory;

    public int xStart;
    public int yStart;
    public int xSpace;
    public int ySpace;
    public int columns;

    Dictionary<itemObject, GameObject> itemsDisplayed = new Dictionary<itemObject, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        createDisply();
    }

    // Update is called once per frame
    void Update()
    {
        updateDisplay();
    }

   public void createDisply()
    {
        for( int i = 0; i < inventory.items.Count; i++)
        {
            var obj = Instantiate(inventory.items[i].prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPos(i);
            itemsDisplayed.Add(inventory.items[i], obj);
        }
    }
    public void updateDisplay()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if(!itemsDisplayed.ContainsKey(inventory.items[i]))
            {
                var obj = Instantiate(inventory.items[i].prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPos(i);
                itemsDisplayed.Add(inventory.items[i], obj);
            }
        }
    }

    public void restartGame()
    {
        itemsDisplayed.Clear();
    }

    public Vector3 GetPos(int i)
    {
        return new Vector3(xStart +(xSpace * (i % columns)),yStart + (-ySpace * (i/columns)),0f);
    }
}
