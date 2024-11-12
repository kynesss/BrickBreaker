using UnityEngine;
using Random = UnityEngine.Random;

namespace Ball
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private float initialSpeed = 10f;
        [SerializeField] private float bounceSpeedBonus = 1.2f;

        private Rigidbody2D _rb;
        private BallCollision _collision;
        
        private Vector2 _currentVelocity;
        private float _bounceCounter;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _collision = GetComponent<BallCollision>();
        }

        private void OnEnable()
        {
            _collision.BounceThresholdReached += OnBounceThresholdReached;
        }

        private void OnDisable()
        {
            _collision.BounceThresholdReached -= OnBounceThresholdReached;
        }

        private void Start()
        {
            AddInitialForce();
        }

        private void Update()
        {
            _currentVelocity = _rb.velocity;
        }

        private void OnBounceThresholdReached()
        {
            ApplyBounceSpeed();
        }

        private void ApplyBounceSpeed()
        {
            _rb.velocity *= bounceSpeedBonus;
        }

        private void AddInitialForce()
        {
            var randomX = Random.Range(-1f, 1f);
            var direction = new Vector2(randomX, -1f);
            
            _rb.AddForce(direction * initialSpeed, ForceMode2D.Impulse);
        }

        public void SetVelocity(Vector2 velocity)
        {
            _rb.velocity = velocity;
        }

        public Vector2 GetVelocity()
        {
            return _currentVelocity;
        }
    }
}