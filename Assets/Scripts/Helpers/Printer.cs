using UnityEngine;

namespace Helpers
{
    public class Printer : MonoBehaviour
    {
        public void Print(object message) => Debug.Log(message);
        public void Print(string message) => Debug.Log(message);
    }
}