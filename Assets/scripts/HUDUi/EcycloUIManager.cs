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

    [SerializeField] Text titleUIText;
    [SerializeField] Text descriptionUIText;
    [SerializeField] Text factsUIText;
    [SerializeField] Image expandImage;

    [SerializeField] Button closeUIButton;

   

    public List<GameObject> uiElemants;

    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        closeUIButton.onClick.RemoveAllListeners();
        closeUIButton.onClick.AddListener(hideExpanded);

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
        updateUI();
    }

    public void updateUI()
    {
        foreach (var elemant in uiElemants)
        {
            Text test = elemant.GetComponentInChildren<Text>();
            Image image = elemant.GetComponentInChildren<Image>();
            Button buttonElemant = elemant.GetComponentInChildren<Button>();
            
            if (elemant.GetComponent<access>().info.locked == true && test)
            {
                test.text = "LOCKED";
                image.sprite = elemant.GetComponent<access>().info.thumb;
                buttonElemant.GetComponent<Image>().color = Color.gray;
            }
            else
            {
                test.text = (elemant.GetComponent<access>().info.name + "\n" 
                            + (elemant.GetComponent<access>().info.description));
                image.sprite = elemant.GetComponent<access>().info.thumb;
                buttonElemant.GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void Show()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        MainCanvas.SetActive(true);
    }

    public void Hide()
    {
        ExpandLayout.SetActive(false);
        MainCanvas.SetActive(false);
    }

    public void hideExpanded()
    {
        ExpandLayout.SetActive(false);
    }

    public void expand(Button button)
    {
        if(button.GetComponentInParent<access>().info.locked == false)
        {
            Debug.Log("We're in lads");
            titleUIText.text = button.GetComponentInParent<access>().info.name;
            descriptionUIText.text = button.GetComponentInParent<access>().info.expandedDescription;
            factsUIText.text = button.GetComponentInParent<access>().info.funFacts;
            expandImage.sprite = button.GetComponentInParent<access>().info.image;
            ExpandLayout.SetActive(true);
        }

    }

}
