using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using objectives;

public class ShopButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public void returnToMap()
    {
        SceneManager.LoadScene("MapScene");
    }

    public void addComb()
    {
        if(GameController.Instance.money >= 200 && !GameController.Instance.checkInventory("COMB01"))
        {
             GameController.Instance.addItem("Comb", "Makes a great Gift!", "COMB01");
             GameController.Instance.money -= 200;
        }

    }
    public void addKnife()
    {
        if (GameController.Instance.money >= 10)
        {
            GameController.Instance.addItem("Knife", "A small cutting tool", "KNIFE01");
            GameController.Instance.money -= 10;
        }

    }
    public void addMeat()
    {
        if (GameController.Instance.money >= 30)
        {
            GameController.Instance.addItem("Meat", "A tasty treat!", "MEAT01");
            GameController.Instance.money -= 30;
        }

    }

}