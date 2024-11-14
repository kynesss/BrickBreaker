using Common;
using PowerUps.Effects;
using UnityEngine;

namespace PowerUps
{
    [RequireComponent(typeof(PowerUpEffectFactory))]
    public class PowerUpSpawner : MonoBehaviour, IService
    {
        [SerializeField] private PowerUp powerUpPrefab;

        private PowerUpEffectFactory _factory;

        private void Awake()
        {
            _factory = GetComponent<PowerUpEffectFactory>();
        }

        public PowerUp SpawnRandomPowerUp()
        {
            var effect = _factory.GetRandomPowerUpEffect();
            var powerUp = Instantiate(powerUpPrefab);
            powerUp.Setup(effect);

            return powerUp;
        }
    }
}