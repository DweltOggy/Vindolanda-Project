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
    }


    public class GameController : MonoBehaviour
    {
        public static GameController Instance;
        public Objective[] objectives;

        public Text value;

        void Awake()
        {
            Instance = this;
            objectives = GetComponents<Objective>();

            DontDestroyOnLoad(gameObject);
        }

        void OnGUI()
        {
            foreach(var objectives in objectives)
            {
                string message = objectives.message();
                if(!value.text.Contains(message))
                    value.text +="- " + message + "\n";
            }
        }

        void Update()
        {
            foreach (var objectives in objectives)
            {
                if (objectives.Achieved())
                {
                    Destroy(objectives);
                    value.text = " ";
                }
                    
            }
        }
    }


}

