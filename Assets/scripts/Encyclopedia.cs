using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace knowledge
{
    public class entry
    {
        public int id;
        public bool locked;
        public string name;
        public string description;
        //public Sprite image;

        public entry(int id, string name, string desc)
        {
            locked = true;
            this.id = id;
            this.name = name;
            this.description = desc;
        }

        public void unlock()
        {
            locked = false;
        }

    }

    public class Encyclopedia : MonoBehaviour
    {
        public static Encyclopedia Instance;

        [SerializeField] public List<entry> enteries = new List<entry>();


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

            createDataBase();
            DontDestroyOnLoad(this.gameObject);
        }

        public void unlockEntry(int id)
        {
            enteries.Find(entry => entry.id == id).unlock();
        }

        public void unlockEntry(string itemName)
        {
            enteries.Find(entry => entry.name == itemName).unlock();
        }

        void createDataBase()
        {
            enteries = new List<entry>() { 
            new entry(0, "Vindolanda",
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST" +
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST" +
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST"),

            new entry(1, "Bath House",
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST" +
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST" +
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST"),

            new entry(2, "Barracks",
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST" +
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST" +
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST"),

            new entry(3, "Temple",
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST" +
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST" +
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST"),

            new entry(4, "Barracks",
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST" +
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST" +
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST"),

            new entry(5, "Barracks",
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST" +
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST" +
                        "TESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTESTTEST")
            };

        }

    }

}

