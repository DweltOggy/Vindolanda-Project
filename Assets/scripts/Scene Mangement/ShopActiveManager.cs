using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopActiveManager : MonoBehaviour
{

    void Awake()
    {
        if(ShopButtons.Instance)
            ShopButtons.Instance.gameObject.SetActive(true);
    }

  
}
