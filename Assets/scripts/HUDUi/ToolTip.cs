using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ToolTip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;
    public LayoutElement layoutElemant;
    public int characterWrapLimit;

    public RectTransform rectTrasform;

    private void Awake()
    {
        rectTrasform = GetComponent<RectTransform>();
    }
    public void SetText(string content, string header = "")
    {
        if(string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }

        contentField.text = content;

        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElemant.enabled = (headerLength > characterWrapLimit || contentLength >characterWrapLimit) ? true : false;
    
    }

    private void Update()
    {
        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTrasform.pivot = new Vector2(pivotX, pivotY);

        transform.position = position;

    }

}
