using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using knowledge;

namespace objectives
{
    public struct item
    {
        public string name;
        public string description;
        public string objID;
    }

    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        public List <Objective> objectives = new List<Objective>();
        public List <item> inventory = new List<item>();
        public int money = 30;

        public Text value;
        public Text displayMoney;
        public Text percentage;

        public bool disableMouseClick= false;

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

           displayMoney.text = "Money: " + money;
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

        public void addItem(string name, string desc, string ID)
        {
            if(!checkInventory(name))
            {
                item entry;
                entry.name = name;
                entry.description = desc;
                entry.objID = ID;
                inventory.Add(entry);
            }
        }

        public bool checkInventory(string Id)
        {
            foreach (var entry in inventory)
                if(entry.objID == Id)
                    return true;
           
                return false;
        }

        public bool checkInventoryName(string name)
        {
            foreach (var entry in inventory)
                if (entry.name == name)
                    return true;

            return false;
        }

    }


}

