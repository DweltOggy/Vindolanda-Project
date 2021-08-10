using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BathHouseQuest3 : Objective
{
    public string info = "Give the Supplies to Manius";
    public int reward = 50;

    public Dialogue Dialogue1;
    public Dialogue Dialogue2;
    public void Start()
    {
        QuestDialogues dialogueStore = FindObjectOfType<QuestDialogues>();

        Dialogue1 = dialogueStore.BathQuest3;
        Dialogue2 = dialogueStore.BathQuest4;

        setDialogue();

    }
    public override bool Achieved()
    {
        if (FindObjectOfType<DialogueManger>().currentNPC == "Manius Rex")
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
        GameObject NPC = GameObject.FindGameObjectWithTag("BathQuest");
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
