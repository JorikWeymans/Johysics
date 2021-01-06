//Created by Jorik Weymans 2020
using UnityEngine;

namespace Jorik.Utilities
{
    //Templated class to make singletons
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _Instance = null;
        private static bool _appIsQuiting = false;

        public static T Instance()
        {
            if (_Instance == null && !_appIsQuiting)
            {
                _Instance = FindObjectOfType<T>();
                if (!_Instance)
                {
                    GameObject newObject = new GameObject("SingleTon " + typeof(T).Name);
                    _Instance = newObject.AddComponent<T>();

                    DontDestroyOnLoad(newObject);
                }
            }
            return _Instance;
        }

        private void OnApplicationQuit()
        {
            _appIsQuiting = true;
        }

    }
}
