using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PopUps;

public class SelectObject : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    bool active = true;
    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit))
            {
                if (Input.GetMouseButtonDown(0) && hit.collider.tag == "Interest")
                {
                    print(hit.collider.name);
                    string title = hit.collider.GetComponent<InterestPoint>().label;
                    string Desc = hit.collider.GetComponent<InterestPoint>().Description;
                    string Destination = hit.collider.GetComponent<InterestPoint>().destination;

                    PopUpUI.Instance.setTitle(title).setDescription(Desc).setDestination(Destination).Show();
                }
            }

        }

    }
}
