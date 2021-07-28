using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManger : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentances;

    public string currentNPC = " ";
    public bool inDialogue = false;
    // Start is called before the first frame update
    void Start()
    {
        sentances = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        if (FindObjectOfType<MouseLook>())
        {
            FindObjectOfType<MouseLook>().MouseEnabled = false;
            FindObjectOfType<PlayerMovement>().MovementEnabled = false;
        }
        inDialogue = true;
        nameText.text = dialogue.name;
        currentNPC = dialogue.name;

        sentances.Clear();

        foreach(string sentance in dialogue.sentances)
        {
            sentances.Enqueue(sentance);
        }
        DisplayNextSentance();
    }

    public void DisplayNextSentance()
    {
        if(sentances.Count == 0)
        { 
            inDialogue = false;
            endDialogue();
            return;
        }

        string sentance = sentances.Dequeue();
        dialogueText.text = sentance;
    }

    void endDialogue()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if(FindObjectOfType<MouseLook>())
        {
            FindObjectOfType<MouseLook>().MouseEnabled = true;
            FindObjectOfType<PlayerMovement>().MovementEnabled = true;
        }
        
        currentNPC = " ";

        animator.SetBool("isOpen", false);
    }

}
