using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TriggerScene : MonoBehaviour
{
    bool inProximity = false;
    float timer = 0.0f;
    public string sceneName = "MapScene";
  
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3.0f && inProximity && Input.GetKeyDown(KeyCode.E))
        {
            LevelLoader.Instance.loadLevel("MapScene");
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
