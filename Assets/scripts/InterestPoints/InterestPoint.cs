using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestPoint : MonoBehaviour
{
    GameObject namePlate;
    public string destination = " ";
    public string label = "Location";
    public string Description = " This is a location ";
    public float distance = 30.0f;
    public float scale = 1.0f;

    public GameObject labelPrefab;
    void Start()
    {
        namePlate = Instantiate(labelPrefab);
        TextMesh textMesh = namePlate.GetComponent<TextMesh>();
        if (textMesh != null)
        {
            namePlate.transform.localScale = namePlate.transform.localScale * scale;
            namePlate.transform.position = transform.position + new Vector3(0, distance, 0);
            textMesh.text = label;
        }
    }

    void Update()
    { 
        namePlate.transform.LookAt(2 * transform.position -  Camera.main.transform.position);
    }
}
