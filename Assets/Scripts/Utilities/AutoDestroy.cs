//Created by Jorik Weymans 2020
using UnityEngine;

namespace Jorik.Utilities
{
    public sealed class AutoDestroy : MonoBehaviour
    {
        [SerializeField] private float _TimeAlive = 2.0f;
        [SerializeField] private bool _StartOnAwake = false;
        
        private void Awake()
        {
            if(_StartOnAwake)
                Destroy(gameObject, _TimeAlive);
        }

        public void InvokeDestroy()
        {
            InvokeDestroy(_TimeAlive);
        }

        public void InvokeDestroy(float time)
        {
            Destroy(gameObject, time);
        }
    }
}
