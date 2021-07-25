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

    [SerializeField] GameObject ExpandLayout;



    List<GameObject> uiElemants;

    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        int loopcounter = 0;
        foreach (var entry in Encyclopedia.Instance.enteries)
        {
            Vector3 offset = new Vector3(0, -320, 0);
            GameObject UIElemant;

            UIElemant = Instantiate(EntryLayout, new Vector3(0, 0, 0) + (offset * loopcounter++), Quaternion.identity) as GameObject;
            UIElemant.transform.SetParent(Parent.transform, false);
            UIElemant.AddComponent<access>();
            UIElemant.GetComponent<access>().info = entry;

            Button buttonElemant = UIElemant.GetComponentInChildren<Button>();
            buttonElemant.onClick.RemoveAllListeners();
            buttonElemant.onClick.AddListener(() => expand(buttonElemant));

            uiElemants.Add(UIElemant);
        }
        updateUI();
    }

    // Update is called once per frame
    void Update()
    {

        if (active && Input.GetKeyDown(KeyCode.J))
        {
            active = false;
            Hide();
        }
        else if (!active && Input.GetKeyDown(KeyCode.J))
        {
            active = true;
            Show();
        }
    }

    public void updateUI()
    {
        foreach (var elemant in uiElemants)
        {
            Text test = elemant.GetComponentInChildren<Text>();
            Button buttonElemant = elemant.GetComponentInChildren<Button>();
            
            if (elemant.GetComponent<access>().info.locked == true && test)
            {
                test.text = "LOCKED";
                buttonElemant.GetComponent<Image>().color = Color.black;
            }
            else
            {
                test.text = (elemant.GetComponent<access>().info.name + "\n" 
                            + (elemant.GetComponent<access>().info.description));
                buttonElemant.GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void Show()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        //FindObjectOfType<MouseLook>().MouseEnabled = false;
        //FindObjectOfType<PlayerMovement>().MovementEnabled = false;
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
        //FindObjectOfType<MouseLook>().MouseEnabled = true;
        //FindObjectOfType<PlayerMovement>().MovementEnabled = true;

        MainCanvas.SetActive(false);
    }

    public void expand(Button button)
    {
        ExpandLayout.SetActive(true);
    }

}
