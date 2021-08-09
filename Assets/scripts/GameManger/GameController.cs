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


        public void removeString(string A)
        {
            value.text.Replace(A, string.Empty);
        }


        void Update()
        {
            refresh();
            foreach (var objective in objectives)
            {

                string message = objective.message();
                if (!value.text.Contains(message))
                    value.text += "- " + message + "\n \n";

                if (objective.Achieved())
                {
                    objective.complete();
                    Destroy(objective);
                    value.text = "";
                }
            }
            percentage.text = "Journal (J) \n" + Encyclopedia.Instance.percentageComplete() + "%";
        }

        public void refresh()
        {
            objectives.Clear();
            objectives.AddRange(GameObject.FindObjectsOfType<Objective>());
        }

        public void restart()
        {
            value.text = "";
            quizStage = 0;
            objectives.Clear();
        }

        public void endGame()
        {
            endCanvas.SetActive(true);
        }
    }
}

