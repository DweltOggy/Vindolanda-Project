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
        int loopcounter = 0;
      foreach (var entry in Encyclopedia.Instance.enteries)
        {
            Vector3 offset = new Vector3(0, -320, 0);
            GameObject UIElemant;
            UIElemant = Instantiate(EntryLayout, new Vector3(0, 0, 0) + (offset * loopcounter++), Quaternion.identity) as GameObject;
            UIElemant.transform.SetParent(Parent.transform,false);
            // UIElemant.getComponent
            Text test = UIElemant.GetComponent<Text>();
            if (entry.locked == true && test)
            {
              test.text = "LOCKED";
            }
            //else
            //{
            //    UIElemant.GetComponent<Text>().text = entry.name + "/n" + entry.description;
            //}

        }
    }

    public void Show()
    {
        MainCanvas.SetActive(true);
    }

    public void Hide()
    {
        MainCanvas.SetActive(false);
    }

}
