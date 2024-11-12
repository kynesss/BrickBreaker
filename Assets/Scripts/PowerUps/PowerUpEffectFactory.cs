using UnityEngine;

namespace PowerUps
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