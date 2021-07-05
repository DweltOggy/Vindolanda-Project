using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace knowledge
{
    public struct entry
    {
        int id;
        string name;

        [TextArea(3, 10)]
        string descrition;
    }

    public class Encyclopedia : MonoBehaviour
    {
        public static Encyclopedia Instance;
        public List<entry> Locations = new List<entry>();


    }

}

