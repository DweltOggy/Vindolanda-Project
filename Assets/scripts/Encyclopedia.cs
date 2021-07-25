using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace knowledge
{
   
    public class Encyclopedia : MonoBehaviour
    {
        public static Encyclopedia Instance;

        [SerializeField] public List<entry> enteries;// = new List<entry>();

        public void Start()
        {
            int counter = 0;
            foreach (var entry in enteries)
            {
                entry.lockEntry();
                entry.id = counter++;
            }
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            else if (Instance != this)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        }
        private void OnApplicationQuit()
        {
            foreach (var entry in enteries)
            {
                entry.lockEntry();
            }
        }

        public void unlockEntry(int id)
        {
            enteries.Find(entry => entry.id == id).unlock();
        }

        public void unlockEntry(string itemName)
        {
            enteries.Find(entry => entry.name == itemName).unlock();
        }

        public float percentageComplete() 
        {
            float completed = 0;
            foreach (var entry in enteries)
            {
                if (entry.locked == false)
                    completed++;
            }

            return Mathf.Round((completed / enteries.Count) * 100);
        }

    }

}

