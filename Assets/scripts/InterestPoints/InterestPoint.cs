using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestPoint : MonoBehaviour
{
    GameObject namePlate;
    private GameObject MainCamera;

    public string destination = " ";
    public string label = "Location";
    public string Description = " This is a location ";

    void Start()
    {

        // Add namePlate here after instaniation.
        namePlate = new GameObject("NamePlate");
        namePlate.AddComponent<TextMesh>();

        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        TextMesh textMesh = namePlate.GetComponent<TextMesh>();
        if (textMesh != null)
        {
            Debug.Log("Adding Nameplate");
            textMesh.transform.position = transform.position + new Vector3(0, 30.0f, 0);  
            textMesh.transform.Rotate(Vector3.up - new Vector3(0, 180, 0));
            textMesh.characterSize = 0.2f;
            textMesh.fontSize = 500;
            textMesh.alignment = TextAlignment.Center;
            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.color = Color.red;
            textMesh.text = label;

        }
    }
    // Update is called once per frame
    void Update()
    { 
        namePlate.transform.LookAt(2 * transform.position - Camera.main.transform.position);
    }
}
