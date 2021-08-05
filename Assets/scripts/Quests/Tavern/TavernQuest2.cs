using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TavernQuest2 : Objective
{
    public string info = "Find Tertius's Key";
    public int reward = 1;

    public Dialogue Dialogue1;
    public Dialogue Dialogue2;
    public itemObject delivery;

    public void Awake()
    {
        QuestDialogues dialogueStore = FindObjectOfType<QuestDialogues>();

        delivery = dialogueStore.key;
        Dialogue1 = dialogueStore.TavernQuest1;
        Dialogue2 = dialogueStore.TavernQuest2;

        DontDestroyOnLoad(this);
    }
    public override bool Achieved()
    {
        if (FindObjectOfType<DialogueManger>().currentNPC == "Scribe")
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
        Player.Instance.addItem(delivery);
        knowledge.Encyclopedia.Instance.unlockEntry(delivery.databaseEntry);
        FindObjectOfType<EcycloUIManager>().updateUI();
        Player.Instance.money += reward;
        if (!Player.Instance.gameObject.GetComponent<TavernQuest3>())
        {
            Player.Instance.gameObject.AddComponent<TavernQuest3>();
        }
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
        GameObject NPC = GameObject.FindGameObjectWithTag("Scribe");
        if (NPC != null)
        {
            recpiant = NPC.GetComponent<NPC>();

            recpiant.setDialogue(Dialogue1);
            recpiant.setAltDialogue(Dialogue2);
        }
    }
}
