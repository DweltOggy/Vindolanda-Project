using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using knowledge;

public class EntryTrigger : MonoBehaviour
{

    public int id = 0;
    public new string audio = "";
    // Start is called before the first frame update
    void Awake()
    {
        if(Encyclopedia.Instance)
        {
            Encyclopedia.Instance.unlockEntry(id);
            //FindObjectOfType<EcycloUIManager>().updateUI();
        }

        if(audio != "" && SoundManager.Instance)
        {
            if(!SoundManager.Instance.alreadyPlaying(audio))
            {
                SoundManager.Instance.stopLoops();
                SoundManager.Instance.Play(audio);
            }
        }
    }

}
