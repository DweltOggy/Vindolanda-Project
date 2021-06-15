using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace objectives
{
    public abstract class Objective : MonoBehaviour
    {
        public abstract bool Achieved();
        public abstract string message();
        public abstract void complete();
    }

    public struct item
    {
        public string name;
        public string description;
    }

    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        public List <Objective> objectives = new List<Objective>();
        public List<item> inventory = new List<item>();
        public int money = 1000;

        public Text value;
        public Text displayMoney;

        void Awake()
        {
            Instance = this;
            objectives.AddRange(GetComponents<Objective>());

            DontDestroyOnLoad(gameObject);
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
        }

        void Update()
        {
            foreach (var objective in objectives)
            {
                if (objective.Achieved())
                {
                    objective.complete();
                    //objectives.Remove(objective);
                    Destroy(objective);
                    value.text = " ";
                }
            }

            for (var i = objectives.Count - 1; i > -1; i--)
            {
                if (objectives[i] == null)
                    objectives.RemoveAt(i);
            }
        }

        public void addItem(string name, string desc)
        {
            item entry;
            entry.name = name;
            entry.description = desc;
            inventory.Add(entry);
        }

    }


}

