using PaddleStuff;
using UnityEngine;

namespace PowerUps
{
    [CreateAssetMenu(menuName = "PowerUps/ExtendPaddleEffect", fileName = "ExtendPaddleEffect")]
    public class ExtendPaddlePowerUpEffect : PowerUpEffect
    {
        [SerializeField] private Sprite regularPaddleSprite;
        [SerializeField] private Sprite extendedPaddleSprite;

        [SerializeField] private float regularColliderWidth = 3.789063f;
        [SerializeField] private float extendedColliderWidth = 5.414063f;
        
        private Paddle _paddle;
        
        public override bool TryApply(GameObject target)
        {
            if (!target.TryGetComponent<Paddle>(out var paddle))
                return false;

            _paddle = paddle;
            UpdateEffect(extendedPaddleSprite, extendedColliderWidth);
            
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