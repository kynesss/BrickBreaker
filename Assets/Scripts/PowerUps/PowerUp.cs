using Common;
using UnityEngine;

namespace PowerUps
{
    public class PowerUp : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private PowerUpEffect _effect;
        private GameObject _target;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_effect.TryApply(other.gameObject))
                return;

            OnEffectApplied();
        }

        private void OnEffectApplied()
        {
            Services.PowerUpEffectManager.AddEffect(_effect);
            Destroy(gameObject);
        }

        public void Setup(PowerUpEffect effect)
        {
            _effect = effect;
            _spriteRenderer.sprite = effect.Icon;
        }
    }
}