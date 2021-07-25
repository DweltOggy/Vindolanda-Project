using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;
using knowledge;

public class Collect : MonoBehaviour
{
    bool inProximity = false;
    public itemObject item;

    private void Start()
    {
        if(item.objID == "REPLACE")
            item.objID = name + transform.position.ToString() + transform.eulerAngles.ToString();

        if(GameController.Instance.playerInventory.checkInventory(item.objID))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (inProximity && Input.GetKeyDown(KeyCode.E))
        {
            Encyclopedia.Instance.unlockEntry(item.databaseEntry);
            FindObjectOfType<EcycloUIManager>().updateUI();

            if(item)
                GameController.Instance.addItem(item);
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            inProximity = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            inProximity = false;
    }
}
