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

        public bool first = true;
        bool main = false;
        public GameObject StartBackGround;

        public Text value;
        public Text percentage;

        public Dialogue openingDiag;

        public int quizStage = 0;

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

        void OnGUI()
        {
            foreach(var objective in objectives)
            {
                string message = objective.message();
                if(!value.text.Contains(message))
                    value.text +="- " + message + "\n";
            }
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
    }
}

