using System;
using UnityEngine;

namespace TheCreators
{
    public class CustomEvent : MonoBehaviour
    {
        private event Action _action = delegate { };

        public void Invoke()
        {
            _action.Invoke();
        }

        public void AddListener(Action listener)
        {
            _action += listener;
        }

        public void RemoveListener(Action listener)
        {
            _action -= listener;
        }
    }
}
