using Ball;
using UnityEngine;

namespace PaddleStuff
{
    public class PaddleBounceHandler : MonoBehaviour
    {
        [SerializeField] private float maxAllowedBounceAngle = 160f;
        [SerializeField] private float minAllowedBounceAngle = 20f;
        
        private BoxCollider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.transform.TryGetComponent<BallMovement>(out var ball)) 
                return;

            var adjustedVelocity = GetReflectedVelocity(collision, ball.GetVelocity());
            ball.SetVelocity(adjustedVelocity);
        }

        private Vector2 GetReflectedVelocity(Collision2D collision, Vector2 incomingVelocity)
        {
            float normalizedOffset = CalculateNormalizedOffset(collision.contacts[0].point.x);
            incomingVelocity = AdjustBounceAngleIfNeeded(incomingVelocity);
            
            var reflection = Vector2.Reflect(incomingVelocity, collision.contacts[0].normal);
            var offsetVector = Vector2.right * normalizedOffset;
            var adjustedSpeed = incomingVelocity.magnitude;

            return (reflection + offsetVector).normalized * adjustedSpeed;
        }

        private float CalculateNormalizedOffset(float collisionPointX)
        {
            return (collisionPointX - transform.position.x) / (_collider.size.x / 2f);
        }

        private Vector2 AdjustBounceAngleIfNeeded(Vector2 velocity)
        {
            var angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            var absAngle = Mathf.Abs(angle);

            if (absAngle > maxAllowedBounceAngle || absAngle < minAllowedBounceAngle)
            {
                var clampedAngle = Mathf.Clamp(angle, minAllowedBounceAngle, maxAllowedBounceAngle) * Mathf.Sign(angle);
                var radians = clampedAngle * Mathf.Deg2Rad;
                
                velocity = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized * velocity.magnitude;
            }

            return velocity;
        }
    }
}
