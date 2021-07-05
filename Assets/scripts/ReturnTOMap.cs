using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnTOMap : MonoBehaviour
{
    float timer = 0.0f;
    bool canExit = false;

    private void Update()
    {
        timer += Time.deltaTime;

        if (canExit && Input.GetKeyDown(KeyCode.E))
            returnToMap();
    }

    void OnTriggerEnter(Collider other)
    {
        if(timer > 3.0f && other.tag == "Player" )
            canExit = true;
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            canExit = false;
    }

    void returnToMap()
    {
        SceneManager.LoadScene("MapScene");
    }
}
