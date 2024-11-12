using UnityEngine;

namespace PowerUps
{
    public class PowerUp : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody;
        
        private PowerUpEffect _effect;
        private GameObject _target;

        private float _effectTimer;
        private bool _isApplied;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_isApplied)
                ProcessEffect();
        }

        private void ProcessEffect()
        {
            if (_effectTimer > 0f)
            {
                _effectTimer -= Time.deltaTime;
            }
            else
            {
                OnEffectRemoved();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_effect.TryApply(other.gameObject))
                return;

            OnEffectApplied();
        }

        private void OnEffectRemoved()
        {
            _effect.Remove(_target);
            Destroy(gameObject);
        }

        private void OnEffectApplied()
        {
            _effectTimer = _effect.Duration;
            _spriteRenderer.sprite = null;
            _rigidbody.simulated = false;
            _isApplied = true;
        }

        public void Setup(PowerUpEffect effect)
        {
            _effect = effect;
            _spriteRenderer.sprite = effect.Icon;
        }
    }
}