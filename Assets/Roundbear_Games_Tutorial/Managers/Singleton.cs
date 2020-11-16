using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance = null;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(T).ToString();
                    _instance = go.AddComponent<T>();
                }
                return _instance;
            }
        }
    }
}
