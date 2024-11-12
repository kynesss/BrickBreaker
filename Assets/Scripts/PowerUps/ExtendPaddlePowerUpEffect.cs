using Paddle;
using UnityEngine;

namespace PowerUps
{
    [CreateAssetMenu(menuName = "PowerUps/ExtendPaddleEffect", fileName = "ExtendPaddleEffect")]
    public class ExtendPaddlePowerUpEffect : PowerUpEffect
    {
        public override bool TryApply(GameObject target)
        {
            if (!target.TryGetComponent<PaddleMovement>(out var paddle))
                return false;
            
            Debug.Log($"Apply: {nameof(ExtendPaddlePowerUpEffect)}!");
            return true;
        }

        public override void Remove(GameObject target)
        {
            Debug.Log($"Remove: {nameof(ExtendPaddlePowerUpEffect)}!");
        }
    }
}