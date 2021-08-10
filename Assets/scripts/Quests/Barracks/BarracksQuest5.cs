using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;
using UnityEngine.SceneManagement;

public class BarracksQuest5 : Objective
{

    public string info = "Return Gaius' Bow";
    public int reward = 70;

    public Dialogue Dialogue1;
    public Dialogue Dialogue2;
    public void Start()
    {
        QuestDialogues dialogueStore = FindObjectOfType<QuestDialogues>();

        Dialogue1 = dialogueStore.BarracksDialogue5;
        Dialogue2 = dialogueStore.BarracksDialogue6;
        setDialogue();
    }

    public override bool Achieved()
    {
        if (FindObjectOfType<DialogueManger>().currentNPC == "Gaius Marinus")
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
        Player.Instance.addMoney(reward);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void setDialogue()
    {
        NPC recpiant;
        GameObject NPC = GameObject.FindGameObjectWithTag("BarracksQuest");
        if (NPC != null)
        {
            recpiant = NPC.GetComponent<NPC>();

            recpiant.setDialogue(Dialogue1);
            recpiant.setAltDialogue(Dialogue2);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        setDialogue();
    }
}
