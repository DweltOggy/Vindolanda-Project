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

        public Text value;
        public Text percentage;

        public int quizStage = 0;

        [SerializeField] GameObject endCanvas;

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
                    value.text +="- " + message + "\n \n";
            }
            percentage.text = "Journal (J) \n" + Encyclopedia.Instance.percentageComplete() + "%";
        }

        void Update()
        {
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

        public void refresh()
        {
            objectives.Clear();
            objectives.AddRange(GameObject.FindObjectsOfType<Objective>());
        }

        public void restart()
        {
            quizStage = 0;
            refresh();
        }

        public void endGame()
        {
            //value.text = " ";
            endCanvas.SetActive(true);
        }
    }
}

