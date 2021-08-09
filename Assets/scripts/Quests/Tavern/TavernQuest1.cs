using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TavernQuest1 : Objective
{

    public string info = "Talk to Tertius Cordus in the Tavern";
    public int reward = 2;

    public int id = 27;

    public Dialogue Dialogue1;
    public Dialogue Dialogue2;
    private void Start()
    {
        QuestDialogues dialogueStore = FindObjectOfType<QuestDialogues>();

        Dialogue1 = dialogueStore.TavernQuestStart;
        Dialogue2 = dialogueStore.TavernQuestALT;

        setDialogue();
    }

    public void Awake()
    {
        QuestDialogues dialogueStore = FindObjectOfType<QuestDialogues>();
        DontDestroyOnLoad(this);
    }
    public override bool Achieved()
    {
        if (FindObjectOfType<DialogueManger>().currentNPC == "Tertius Cordus")
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

        knowledge.Encyclopedia.Instance.unlockEntry(id);

        if (!Player.Instance.gameObject.GetComponent<TavernQuest2>())
        {
            Player.Instance.gameObject.AddComponent<TavernQuest2>();
        }
    }

    public void setDialogue()
    {
        NPC recpiant;
        GameObject NPC = GameObject.FindGameObjectWithTag("TavernQuest");
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
