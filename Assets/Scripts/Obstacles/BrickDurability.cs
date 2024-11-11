using Ball;
using Obstacles.Events;
using UnityEngine;

namespace Obstacles
{
    public class BrickDurability : MonoBehaviour
    {
        private int _durability;
        public event BrickDurabilityChangedEvent Changed;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.TryGetComponent<BallMovement>(out var ball))
                return;

            OnGetHit();
        }

        private void OnGetHit()
        {
            var lastDurability = _durability--;
            Changed?.Invoke(new BrickDurabilityChangedArgs(lastDurability, _durability));

            if (_durability == 0)
            {
                Destroy(gameObject);
            }
        }

        public void Setup(BrickData data)
        {
            _durability = data.Durability;
        }
    }
}
