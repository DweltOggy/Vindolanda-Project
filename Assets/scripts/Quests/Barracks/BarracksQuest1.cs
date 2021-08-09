using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarracksQuest1 : Objective
{
    public string info = "Talk to Gaius Marinus in the Barracks";
    public int reward = 2;

    public Dialogue Dialogue1;
    public Dialogue Dialogue2;
    private void Start()
    {
        QuestDialogues dialogueStore = FindObjectOfType<QuestDialogues>();

        Dialogue1 = dialogueStore.BarracksDialogue1;
        Dialogue2 = dialogueStore.BarracksDialogue2;

        setDialogue();
    }

    public void Awake()
    {
        DontDestroyOnLoad(this);
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
        knowledge.Encyclopedia.Instance.unlockEntry(22);
        if (!Player.Instance.gameObject.GetComponent<BarracksQuest2>())
        {
            Player.Instance.gameObject.AddComponent<BarracksQuest2>();
        }
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
