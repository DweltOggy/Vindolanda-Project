using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace objectives
{
    public abstract class Objective : MonoBehaviour
    {
        public abstract bool Achieved();
        public abstract bool draw();
    }


    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        public Objective[] objectives;

        void Awake()
        {
            objectives = GetComponents<Objective>();
        }

        private void OnGUI()
        {
            
        }

        private void Update()
        {
            
        }
    }
}

