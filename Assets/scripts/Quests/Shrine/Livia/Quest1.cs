using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;
using UnityEngine.SceneManagement;

public class Quest1  : Objective
{

    public string info = "Talk to Livia Pola in the Temple";
    public int reward = 2;
    public itemObject delivery;
    public Dialogue Dialogue1;
    public Dialogue Dialogue2;

    public void Awake()
    {
        QuestDialogues dialogueStore = FindObjectOfType<QuestDialogues>();

        Dialogue1 = dialogueStore.quest1Dialogue1;
        Dialogue2 = dialogueStore.quest1Dialogue2;

        setDialogue();
        delivery = dialogueStore.pendant;
    }
    public override bool Achieved()
    {
        if (FindObjectOfType<DialogueManger>().currentNPC == "Livia Pola")
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
        knowledge.Encyclopedia.Instance.unlockEntry(23);
        knowledge.Encyclopedia.Instance.unlockEntry(delivery.databaseEntry);

        Player.Instance.addMoney(reward);
        if (!Player.Instance.gameObject.GetComponent<Quest2>())
        {
            Player.Instance.gameObject.AddComponent<Quest2>();
        }
    }

    public void setDialogue()
    {
        NPC recpiant;
        GameObject NPC = GameObject.FindGameObjectWithTag("ShrineQuest");
        if (NPC != null)
        {
            recpiant = NPC.GetComponent<NPC>();

            recpiant.setDialogue(Dialogue1);
            recpiant.setAltDialogue(Dialogue2);
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
        setDialogue();
    }

}
