using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BathHouseQuest1 : Objective
{
    public string info = "Talk to Manius Rex in the Bath House";
    public int reward = 15;

    public Dialogue Dialogue1;
    public Dialogue Dialogue2;

    private void Start()
    {
        QuestDialogues dialogueStore = FindObjectOfType<QuestDialogues>();

        Dialogue1 = dialogueStore.BathQuest1;
        Dialogue2 = dialogueStore.BathQuest2;

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
        knowledge.Encyclopedia.Instance.unlockEntry(25);
        if (!Player.Instance.gameObject.GetComponent<BathHouseQuest2>())
        {
            Player.Instance.gameObject.AddComponent<BathHouseQuest2>();
        }
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
