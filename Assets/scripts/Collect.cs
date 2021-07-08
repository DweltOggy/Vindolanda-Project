using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;

public class Collect : MonoBehaviour
{
    bool inProximity = false;

    public string title = "name";
    public string desc = "Test Description";
    public string objectID;

    private void Start()
    {
        objectID = name + transform.position.ToString() + transform.eulerAngles.ToString();

        if(GameController.Instance.checkInventory(objectID))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inProximity && Input.GetKeyDown(KeyCode.E))
        {
            GameController.Instance.addItem(title, desc, objectID);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inProximity = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            inProximity = false;
    }
}
