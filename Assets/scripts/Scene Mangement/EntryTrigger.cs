using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using knowledge;

public class EntryTrigger : MonoBehaviour
{

    public int id = 0;
    // Start is called before the first frame update
    void Awake()
    {
        Encyclopedia.Instance.unlockEntry(id);
        FindObjectOfType<EcycloUIManager>().updateUI();
    }

}
