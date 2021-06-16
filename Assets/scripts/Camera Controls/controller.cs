using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float speed = 100f;

    public Vector2 limits;

    public float scrollSpeed = 10f;
    public float minY = 20f;
    public float maxY = 120f;

    public float senstivity = 50f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        Vector3 pos = transform.position;
     
        if (Input.GetKey("w"))
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x += speed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, -limits.x, limits.x);
        pos.z = Mathf.Clamp(pos.z, -limits.y, limits.y);

        transform.position = pos;  
        



    }
}
