using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using objectives;
using UnityEngine.UI;
public class ShopButtons : MonoBehaviour
{
    [SerializeField] public List<itemObject> items;

    [SerializeField] GameObject Parent;
    [SerializeField] GameObject EntryLayout;

    public static ShopButtons Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        int loopcounter = 0;
        foreach (var item in items)
        {
            Vector3 offset = new Vector3(0, -120, 0);
            GameObject UIElemant;

            UIElemant = Instantiate(EntryLayout, new Vector3(0, 130, 0) + (offset * loopcounter++), Quaternion.identity) as GameObject;
            UIElemant.transform.SetParent(Parent.transform, false);
            UIElemant.AddComponent<access>();
            UIElemant.GetComponent<access>().item = item;
            UIElemant.GetComponentInChildren<Text>().text = item.name + " : " + item.value.ToString();

            Button buttonElemant = UIElemant.GetComponentInChildren<Button>();
            buttonElemant.onClick.RemoveAllListeners();
            buttonElemant.onClick.AddListener(() => buyItem(buttonElemant));
        }
    }

    private void Update()
    {
        //this.gameObject.SetActive(true);
    }
    public void returnToMap()
    {
        gameObject.SetActive(false);
        LevelLoader.Instance.loadLevel("MapScene");
    }
    public void buyItem(Button button)
    {
        access info = button.GetComponentInParent<access>();

        if(GameController.Instance.money > info.item.value)
        {
            GameController.Instance.addItem(info.item);
            GameController.Instance.money -= info.item.value;
            Destroy(button.gameObject);//.SetActive(false);
        }
    }


}
