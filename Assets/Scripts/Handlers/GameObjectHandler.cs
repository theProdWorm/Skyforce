using UnityEngine;

namespace Handlers
{
    public class GameObjectHandler : MonoBehaviour
    {
        public void DestroyGameObject(GameObject obj) => Destroy(obj);
        
        public int GetObjectCountByTag(string targetTag) => GameObject.FindGameObjectsWithTag(targetTag).Length;
    }
}