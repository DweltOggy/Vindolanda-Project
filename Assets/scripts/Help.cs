using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    [SerializeField] GameObject HelpCanvas;
    bool active = true;
    void Update()
    {

        if (active && Input.GetKeyDown(KeyCode.C))
        {
            hide();
        }
        else if (!active && Input.GetKeyDown(KeyCode.C))
        {
            show();
        }
    }

    void show()
    { 
        active = true;
        HelpCanvas.SetActive(true);
    }

    public void hide()
    {
        active = false;
        HelpCanvas.SetActive(false);
    }
}
