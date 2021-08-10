using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectives;

public class NPC : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue altDialogue;
    bool inProximity = false;

    void Update()
    {
        if (inProximity && Input.GetKeyDown(KeyCode.E))
        {
            triggerDialogue();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inProximity = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            inProximity = false;
    }
    public void triggerDialogue()
    {
        DialogueManger.Instance.StartDialogue(dialogue);

        if(altDialogue.sentances.Length > 0)
        {
            altDialogue.name = dialogue.name;
            dialogue = altDialogue;
        }
    }

    public void setDialogue(Dialogue newDiag)
    {
        dialogue = newDiag;
    }
    public void setAltDialogue(Dialogue newDiag)
    {
        altDialogue = newDiag;
    }
}
