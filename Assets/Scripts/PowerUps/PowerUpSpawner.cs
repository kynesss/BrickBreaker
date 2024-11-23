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
        
        public bool TrySpawnPowerUp(out PowerUp powerUp)
        {
            var canDropPowerUp = Random.Range(0f, 100f) <= 20f;
            if (canDropPowerUp == false) 
                powerUp = null;

            var effect = _factory.GetRandomPowerUpByDropChance();
            powerUp = Instantiate(powerUpPrefab);
            powerUp.Setup(effect);

            return true;
        }
    }
}