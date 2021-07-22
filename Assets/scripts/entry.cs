using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace knowledge
{
    [CreateAssetMenu]
    public class entry : ScriptableObject
    {
        public int id;
        public bool locked;
        public new string name;

        [TextArea(10,10)]
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

        public void lockEntry()
        {
            locked = true;
        }

    }
}
