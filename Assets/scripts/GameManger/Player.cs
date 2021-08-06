using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using objectives;
public class Player : MonoBehaviour
{
    public static Player Instance;

    public List<Objective> objectives = new List<Objective>();

    public Inventory playerInventory;
    public int money = 30;

    public GameObject notifier;
    public Text displayMoney;

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

    public void removeItem(itemObject newItem)
    {
       
        playerInventory.removeItem(newItem);
        StartCoroutine(showNotifier(2));
    }

    IEnumerator showNotifier(float delay)
    {
        notifier.SetActive(true);
        yield return new WaitForSeconds(delay);
        notifier.SetActive(false);
    }
}
