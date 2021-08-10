using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDUI : MonoBehaviour
{
   
    [SerializeField] GameObject ObjectiveCanvas;
    [SerializeField] GameObject InventoryCanvas;
    public Animator animator;

    bool active = false;

    void Update()
    {

        if (active && Input.GetKeyDown(KeyCode.Q))
        {
            active = false;
            Hide(true);
        }
        else if (!active && Input.GetKeyDown(KeyCode.Q))
        {
            active = true;
            Show(true);
        }

        if (active && Input.GetKeyDown(KeyCode.I))
        {
            active = false;
            Hide(false);
        }
        else if (!active && Input.GetKeyDown(KeyCode.I))
        {
            active = true;
            Show(false);
        }
    }

    public void Show(bool obj)
    {
        if (obj)
        { 
            ObjectiveCanvas.SetActive(true); 
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
            
        else
        {
            animator.SetBool("isOpen", true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
           
    }

    public void Hide(bool obj)
    {
        if (obj)
        {  
            ObjectiveCanvas.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
           
        else
        {
            animator.SetBool("isOpen", false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }  
    }
}
