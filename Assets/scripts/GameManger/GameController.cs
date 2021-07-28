using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using knowledge;

namespace objectives
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        public List <Objective> objectives = new List<Objective>();
    
        public Inventory playerInventory;
        public int money = 30;


        public bool first = true;
        bool main = false;
        public GameObject StartBackGround;

        public Text value;
        public Text displayMoney;
        public Text percentage;

        public GameObject notifier;
        public GameObject UI;

        public Dialogue openingDiag;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;         
            }
            else if (Instance != this)
            {
                Destroy(this.gameObject);
            }
            objectives.AddRange(GameObject.FindObjectsOfType<Objective>());
            DontDestroyOnLoad(this.gameObject);
        }

        private void OnApplicationQuit()
        {
            playerInventory.clearInventory();
        }

        void OnGUI()
        {
            foreach(var objective in objectives)
            {
                string message = objective.message();
                if(!value.text.Contains(message))
                    value.text +="- " + message + "\n";
            }
            displayMoney.text = "Money: " + money;
            percentage.text = "Journal (J) \n" + Encyclopedia.Instance.percentageComplete() + "%";
        }

        void Update()
        {
            if (first)
                playStart();
            else if (!main)
                endStart();

            foreach (var objective in objectives)
            {
                if (objective.Achieved())
                {
                    objective.complete();
                    Destroy(objective);
                    value.text = " ";
                }
            }
            refresh();
        }

        void playStart()
        {
            DialogueManger manager = FindObjectOfType<DialogueManger>();
            manager.StartDialogue(openingDiag);
            StartBackGround.SetActive(true);
            first = false;
        }
        void endStart()
        {
            DialogueManger manager = FindObjectOfType<DialogueManger>();
            if(!first && !main)
            {
                if (!manager.inDialogue)
                {
                    main = true;
                    StartBackGround.SetActive(false);
                }
            }
        }

        public void refresh()
        {
            objectives.Clear();
            objectives.AddRange(GameObject.FindObjectsOfType<Objective>());
        }

        public void addItem(itemObject newItem)
        {
            playerInventory.addItem(newItem);
            StartCoroutine(showNotifier(2));
        }

        IEnumerator showNotifier(float delay)
        {
            notifier.SetActive(true);
            yield return new WaitForSeconds(delay);
            notifier.SetActive(false);
        }
    }
}

