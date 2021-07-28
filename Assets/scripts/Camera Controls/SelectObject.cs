using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PopUps;
using UnityEngine.EventSystems;
public class SelectObject : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    void Update()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit))
            {
                if (Input.GetMouseButtonDown(0) && hit.collider.tag == "Interest")
                {
                    string title = hit.collider.GetComponent<InterestPoint>().label;
                    string Desc = hit.collider.GetComponent<InterestPoint>().Description;
                    string Destination = hit.collider.GetComponent<InterestPoint>().destination;

                    PopUpUI.Instance.setTitle(title).setDescription(Desc).setDestination(Destination).Show();
                }
            }

        }

    }
}
