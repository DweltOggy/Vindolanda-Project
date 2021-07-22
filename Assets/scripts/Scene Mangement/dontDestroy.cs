using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    private static dontDestroy Instance = null;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }


}
