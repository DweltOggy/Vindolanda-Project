using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using knowledge;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EcycloUIManager : MonoBehaviour
{

    [SerializeField] GameObject MainCanvas;
    [SerializeField] GameObject Parent;

    [SerializeField] GameObject EntryLayout;


    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        updateUI();
    }

    // Update is called once per frame
    void Update()
    {

        if (active && Input.GetKeyDown(KeyCode.O))
        {
            active = false;
            Hide();
        }
        else if (!active && Input.GetKeyDown(KeyCode.O))
        {
            active = true;
            Show();
        }
    }

    public void updateUI()
    {
        for(int i = 0; i < Parent.transform.childCount; i++)
        {
            Destroy(Parent.transform.GetChild(i).gameObject);
        }


        int loopcounter = 0;


      foreach (var entry in Encyclopedia.Instance.enteries)
        {
            Vector3 offset = new Vector3(0, -320, 0);
            GameObject UIElemant;
            UIElemant = Instantiate(EntryLayout, new Vector3(0, 0, 0) + (offset * loopcounter++), Quaternion.identity) as GameObject;

            UIElemant.transform.SetParent(Parent.transform,false);
            // UIElemant.getComponent
            Text test = UIElemant.GetComponentInChildren<Text>();
            if (entry.locked == true && test)
            {
              test.text = "LOCKED";
            }
            else
            {
                test.text = entry.name + "\n" + entry.description;
            }

        }
    }

    public void Show()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        FindObjectOfType<MouseLook>().MouseEnabled = false;
        FindObjectOfType<PlayerMovement>().MovementEnabled = false;

        MainCanvas.SetActive(true);
    }

    public void Hide()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "MapScene")
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

           

        FindObjectOfType<MouseLook>().MouseEnabled = true;
        FindObjectOfType<PlayerMovement>().MovementEnabled = true;

        MainCanvas.SetActive(false);
    }

}
