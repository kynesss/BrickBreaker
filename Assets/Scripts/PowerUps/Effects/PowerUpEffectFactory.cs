using UnityEngine;

namespace PowerUps.Effects
{
    public class PowerUpEffectFactory : MonoBehaviour
    {
        [SerializeField] private PowerUpEffect[] powerUpEffects;
        
        public PowerUpEffect GetRandomPowerUpEffect()
        {
            return powerUpEffects[Random.Range(0, powerUpEffects.Length)];
        }
    }
}