using UnityEngine;

namespace Helpers.Debug
{
    public class Printer : MonoBehaviour
    {
        public void Print(object message) => UnityEngine.Debug.Log(message);
        public void Print(string message) => UnityEngine.Debug.Log(message);
    }
}