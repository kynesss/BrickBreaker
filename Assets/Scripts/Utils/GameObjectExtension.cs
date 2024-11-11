using UnityEngine;

namespace Utils
{
    public static class GameObjectExtension
    {
        public static void DestroyAllChildren(this GameObject gameObject)
        {
            foreach (Transform child in gameObject.transform)
            {
                Object.Destroy(child.gameObject);
            }
        }
    }
}