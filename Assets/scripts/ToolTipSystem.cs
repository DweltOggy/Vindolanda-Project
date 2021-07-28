using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipSystem : MonoBehaviour
{
    private static ToolTipSystem Instance;
    public ToolTip tooltip;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        //DontDestroyOnLoad(this.gameObject);
    }

    public static void show(string content, string header = "")
    {
        Instance.tooltip.SetText(content, header);
        Instance.tooltip.gameObject.SetActive(true);
    }

    public static void hide()
    {
        Instance.tooltip.gameObject.SetActive(false);
    }

}
