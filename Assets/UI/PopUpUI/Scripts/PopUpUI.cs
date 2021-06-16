using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace EasyUI.PopUps
{ 

    public class PopUp
    {
        public string Title = " Title";
        public string Description = " Deafault Description. Description wasn't set";
        public string Destination = "MapScene";
    }


    public class PopUpUI : MonoBehaviour
    {
        [SerializeField] GameObject canvas;

        [SerializeField] Text titleUIText;
        [SerializeField] Text descriptionUIText;
        [SerializeField] Button travelUIButton;
        [SerializeField] Button closeUIButton;

        PopUp popup = new PopUp();


        public static PopUpUI Instance;

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

            closeUIButton.onClick.RemoveAllListeners();
            closeUIButton.onClick.AddListener(Hide);

            travelUIButton.onClick.RemoveAllListeners();
            travelUIButton.onClick.AddListener(changeScene);
            travelUIButton.onClick.AddListener(Hide);
        }

        public PopUpUI setTitle(string title)
        {
            popup.Title = title;
            return Instance;
        }

        public PopUpUI setDescription(string desc)
        {
            popup.Description = desc;
            return Instance;
        }

        public PopUpUI setDestination(string dest)
        {
            popup.Destination = dest;
            return Instance;
        }

        public void Show()
        {
            titleUIText.text = popup.Title;
            descriptionUIText.text = popup.Description;
            canvas.SetActive(true);
        }

        public void Hide()
        {
            canvas.SetActive(false);
            popup = new PopUp();
        }

        public void changeScene()
        {
            print("changing scene");
            SceneManager.LoadScene(popup.Destination);
        }

    }
}