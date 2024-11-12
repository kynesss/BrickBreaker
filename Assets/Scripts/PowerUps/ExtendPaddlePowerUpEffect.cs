using PaddleStuff;
using UnityEngine;

namespace PowerUps
{
    [CreateAssetMenu(menuName = "PowerUps/ExtendPaddleEffect", fileName = "ExtendPaddleEffect")]
    public class ExtendPaddlePowerUpEffect : PowerUpEffect
    {
        [SerializeField] private Sprite regularPaddleSprite;
        [SerializeField] private Sprite extendedPaddleSprite;
        
        private Paddle _paddle;
        
        public override bool TryApply(GameObject target)
        {
            if (!target.TryGetComponent<Paddle>(out var paddle))
                return false;

            _paddle = paddle;
            _paddle.Renderer.sprite = extendedPaddleSprite;
            return true;
        }

        public override void Remove()
        {
            _paddle.Renderer.sprite = regularPaddleSprite;
            _paddle = null;
        }
    }
}