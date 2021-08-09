using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using objectives;
public class Player : MonoBehaviour
{
    public static Player Instance;

    public Inventory playerInventory;
    [SerializeField] int money = 30;
    int startMoney;

    public GameObject notifier;
    public Text displayMoney;

    private void Start()
    {
        startMoney = money;
        addStartQuests();
    }

    void addStartQuests()
    {     
        gameObject.AddComponent<FillJournalQuest>();
        gameObject.AddComponent<MainQuest>();
        gameObject.AddComponent<Quest1>();
        gameObject.AddComponent<BarracksQuest1>();
        gameObject.AddComponent<BathHouseQuest1>();
        gameObject.AddComponent<TavernQuest1>();
    }

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

    private void OnApplicationQuit()
    {
        playerInventory.clearInventory();
    }

    void OnGUI()
    {
        displayMoney.text = "Money: " + money;
    }

    public void addItem(itemObject newItem)
    { 
        SoundManager.Instance.Play("Alert");
        playerInventory.addItem(newItem);
        StartCoroutine(showNotifier(2));
    }

    public int moneyVal()
    {
        return money;
    }

    public void addMoney(int value)
    {
        money += value;
    }

    public void subMoney(int value)
    {
        money -= value;
    }

    public void removeItem(itemObject newItem)
    {
        playerInventory.removeItem(newItem);
        StartCoroutine(showNotifier(2));
    }

    public void restart()
    {
        playerInventory.clearInventory();
        foreach (var comp in gameObject.GetComponents<Component>())
        {
            if (!(comp is Transform) && !(comp is Player))
            {
                Destroy(comp);
            }
        }
        money = startMoney;
        addStartQuests();
        GameController.Instance.refresh();
    }

    IEnumerator showNotifier(float delay)
    {
        notifier.SetActive(true);
        yield return new WaitForSeconds(delay);
        notifier.SetActive(false);
    }
}
