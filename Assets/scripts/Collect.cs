using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;

public class Collect : MonoBehaviour
{
    bool inProximity = false;

    public string title = "name";
    public string desc = "Test Description";

    // Update is called once per frame
    void Update()
    {
        if (inProximity && Input.GetKeyDown(KeyCode.E))
        {
            GameController.Instance.addItem(title, desc);
            Destroy(gameObject);
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
