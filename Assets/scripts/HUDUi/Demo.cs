using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PopUps;

public class Demo : MonoBehaviour
{
    private void Start()
    {
        PopUpUI.Instance.setTitle(" Test").setDescription(" We're testing the UI POP up").Show();
    }
}
