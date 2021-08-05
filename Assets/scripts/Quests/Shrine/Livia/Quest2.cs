using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;
using UnityEngine.SceneManagement;

public class Quest2 : Objective
{

    public string info = "Deliver Livia's Pendant to the Tavern Patron";
    public int reward = 2;

    public Dialogue tavernDialogue1;
    public Dialogue tavernDialogue2;

    public itemObject delivery;

    public void Start()
    {
        QuestDialogues dialogueStore = FindObjectOfType<QuestDialogues>();

        tavernDialogue1 = dialogueStore.tavernDialogue1;
        tavernDialogue2 = dialogueStore.tavernDialogue2;

        delivery = dialogueStore.pendant;

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        NPC recpiant;
        GameObject NPC = GameObject.FindGameObjectWithTag("ShrineQuest");
        if (NPC != null)
        {
            recpiant = NPC.GetComponent<NPC>();

            recpiant.setDialogue(tavernDialogue1);
            recpiant.setAltDialogue(tavernDialogue2);
        }
    }

    public void Awake()
    {
 
        //DontDestroyOnLoad(this.gameObject);
    }
    public override bool Achieved()
    {
        if (FindObjectOfType<DialogueManger>().currentNPC == "Tavern Patron")
        {
            return true;
        }
        return false;
    }
    public override string message()
    {
        return (info);
    }

    public override void complete()
    {
        
        Player.Instance.money += reward;
        Player.Instance.removeItem(delivery);

        if (!Player.Instance.gameObject.GetComponent<Quest3>())
        {
            Player.Instance.gameObject.AddComponent<Quest3>();
        }
    }
}
