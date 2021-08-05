using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestPoint : MonoBehaviour
{
    GameObject namePlate;
    public string destination = " ";
    public string label = "Location";
    public string Description = " This is a location ";
    public GameObject labelPrefab;
    void Start()
    {
        namePlate = Instantiate(labelPrefab);
        TextMesh textMesh = namePlate.GetComponent<TextMesh>();
        if (textMesh != null)
        {
            namePlate.transform.position = transform.position + new Vector3(0, 30.0f, 0);
            namePlate.transform.Rotate(Vector3.up - new Vector3(0, 180, 0));
            textMesh.text = label;
        }
    }

    void Update()
    { 
        namePlate.transform.LookAt(2 * transform.position - Camera.main.transform.position);
    }
}
