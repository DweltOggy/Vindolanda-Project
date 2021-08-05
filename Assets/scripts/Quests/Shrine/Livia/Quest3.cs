using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;
using UnityEngine.SceneManagement;

public class Quest3 : Objective
{

    public string info = "Return to Livia Pola in the Temple";
    public int reward = 10;

    public itemObject delivery;

    public Dialogue Dialogue1;
    public Dialogue Dialogue2;
    public void Start()
    {
        QuestDialogues dialogueStore = FindObjectOfType<QuestDialogues>();

        Dialogue1 = dialogueStore.quest3Dialogue1;
        Dialogue2 = dialogueStore.quest3Dialogue2;

        delivery = dialogueStore.artifact;

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
        knowledge.Encyclopedia.Instance.unlockEntry(delivery.databaseEntry);
        FindObjectOfType<EcycloUIManager>().updateUI();
        Player.Instance.money += reward;
        if (!Player.Instance.gameObject.GetComponent<Quest4>())
        {
            Player.Instance.gameObject.AddComponent<Quest4>();
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
        GameObject NPC = GameObject.FindGameObjectWithTag("ShrineQuest");
        if (NPC != null)
        {
            recpiant = NPC.GetComponent<NPC>();

            recpiant.setDialogue(Dialogue1);
            recpiant.setAltDialogue(Dialogue2);
        }
    }
}
