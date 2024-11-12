using Common;
using UnityEngine;

namespace PowerUps
{
    public class PowerUpManager : MonoBehaviour, IService
    {
        [SerializeField] private PowerUp powerUpPrefab;
        [SerializeField] private PowerUpEffect[] powerUpEffects;

        private PowerUpEffect GetRandomPowerUpEffect()
        {
            return powerUpEffects[Random.Range(0, powerUpEffects.Length)];
        }

        public PowerUp SpawnRandomPowerUp()
        {
            var effect = GetRandomPowerUpEffect();
            var powerUp = Instantiate(powerUpPrefab);
            powerUp.Setup(effect);

            return powerUp;
        }
    }
}