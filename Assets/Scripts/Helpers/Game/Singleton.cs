using System.Collections.Generic;
using UnityEngine;

namespace Helpers.Game
{
    public class SingletonByName : MonoBehaviour
    {
        private static readonly Dictionary<string, SingletonByName> _instance = new();
        
        [SerializeField] private bool _favorSelf;
        
        private void Awake()
        {
            if (!_instance.ContainsKey(name))
            {
                _instance[name] = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                if (_favorSelf)
                {
                    Destroy(_instance[name].gameObject);
                    
                    _instance[name] = this;
                    DontDestroyOnLoad(gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}