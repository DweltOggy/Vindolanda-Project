using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace knowledge
{
    [CreateAssetMenu]
    public class entry : ScriptableObject
    {
        public int id;
        public bool locked = true;
        public new string name;

        [TextArea(5,5)]
        public string description;
        [TextArea(10, 10)]
        public string expandedDescription;
        [TextArea(10, 10)]
        public string funFacts;

        public Sprite thumb;// = Resources.Load<Sprite>("lock");
        public Sprite image;// = Resources.Load<Sprite>("lock");

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
