using Ball;
using UnityEngine;

namespace Paddle
{
    public class PaddleCollision : MonoBehaviour
    {
        private BoxCollider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.TryGetComponent<BallMovement>(out var ball)) 
                return;
            
            var newVelocity = CalculateBounceVelocity(other, ball.GetVelocity());
            ball.SetVelocity(newVelocity);
        }

        private Vector2 CalculateBounceVelocity(Collision2D collision, Vector2 incomingVelocity)
        {
            var collisionCenter = collision.contacts[0].point.x;
            var offsetNormalized = (collisionCenter - transform.position.x) / (_collider.size.x / 2f);
            
            var offsetVector = Vector2.right * offsetNormalized;
            var normal = collision.contacts[0].normal;
            var reflection = Vector2.Reflect(incomingVelocity, normal);
            
            var currentSpeed = incomingVelocity.magnitude;
            return (reflection + offsetVector).normalized * currentSpeed;
        }
    }
}