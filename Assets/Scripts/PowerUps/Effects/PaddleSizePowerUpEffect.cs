using PaddleStuff;
using UnityEngine;

namespace PowerUps.Effects
{
    [CreateAssetMenu(menuName = "PowerUps/PaddleSizePowerUpEffect", fileName = "PaddleSizePowerUpEffect")]
    public class PaddleSizePowerUpEffect : PowerUpEffect
    {
        [SerializeField] private Sprite regularPaddleSprite;
        [SerializeField] private Sprite effectPaddleSprite;

        [SerializeField] private float regularColliderWidth = 3.789063f;
        [SerializeField] private float effectColliderWidth;
        
        private Paddle _paddle;
        
        public override bool TryApply(GameObject target)
        {
            if (!target.TryGetComponent<Paddle>(out var paddle))
                return false;

            _paddle = paddle;
            UpdateEffect(effectPaddleSprite, effectColliderWidth);
            
            return true;
        }

        public override void Remove()
        {
            UpdateEffect(regularPaddleSprite, regularColliderWidth);
            _paddle = null;
        }

        private void UpdateEffect(Sprite sprite, float width)
        {
            _paddle.Renderer.sprite = sprite;
            _paddle.Collider.size = new Vector2(width, _paddle.Collider.size.y);
        }
    }
}