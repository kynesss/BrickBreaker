using Common;
using PaddleStuff;
using UnityEngine;

namespace PowerUps.Effects
{
    [CreateAssetMenu(menuName = "PowerUps/ScorePowerUpEffect", fileName = "ScorePowerUpEffect")]
    public class ScorePowerUpEffect : PowerUpEffect
    {
        [SerializeField] private int points;
        
        public override bool TryApply(GameObject target)
        {
            if (!target.TryGetComponent<Paddle>(out _))
                return false;
            
            Services.ScoreManager.AddScore(points);
            return true;
        }

        public override void Remove()
        {
        }
    }
}