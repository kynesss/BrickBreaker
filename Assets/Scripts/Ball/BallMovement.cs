using UnityEngine;
using Random = UnityEngine.Random;

namespace Ball
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private float initialSpeed = 10f;

        private Rigidbody2D _rb;
        private Vector2 _currentVelocity;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            AddInitialForce();
        }

        private void Update()
        {
            _currentVelocity = _rb.velocity;
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