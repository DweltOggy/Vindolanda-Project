using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using objectives;

public class ShopButtons : MonoBehaviour
{
    [SerializeField] public List<itemObject> items;

    // Start is called before the first frame update
    public void returnToMap()
    {
        SceneManager.LoadScene("MapScene");
    }



}
