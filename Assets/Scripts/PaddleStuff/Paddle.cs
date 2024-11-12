using UnityEngine;

namespace PaddleStuff
{
    public class Paddle : MonoBehaviour
    {
        [field: SerializeField] public SpriteRenderer Renderer { get; private set; }
        [field: SerializeField] public BoxCollider2D Collider { get; private set; }

        private void Reset()
        {
            Renderer = GetComponent<SpriteRenderer>();
            Collider = GetComponent<BoxCollider2D>();
        }
    }
}