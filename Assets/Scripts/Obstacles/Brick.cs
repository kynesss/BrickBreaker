using Common;
using Obstacles.Events;
using UnityEngine;

namespace Obstacles
{
    public class Brick : MonoBehaviour
    {
        private BrickDurability _durability;
        private BrickSpriteHandler _spriteHandler;
        private BrickData _data;

        private void Awake()
        {
            _durability = GetComponent<BrickDurability>();
            _spriteHandler = GetComponent<BrickSpriteHandler>();
        }

        private void OnEnable()
        {
            _durability.Changed += OnDurabilityChanged;
        }

        private void OnDisable()
        {
            _durability.Changed -= OnDurabilityChanged;
        }
        
        private void OnDurabilityChanged(BrickDurabilityChangedArgs args)
        {
            if (args.IsAlive)
                return;

            AwardPoints();
            SpawnPowerUp();
        }

        private void AwardPoints()
        {
            var score = _data.Points;
            Services.ScoreManager.AddScore(score);
        }

        private void SpawnPowerUp()
        {
            var powerUpSpawner = Services.PowerUpSpawner;
            if (powerUpSpawner.TrySpawnPowerUp(out var powerUp))
            {
                powerUp.transform.position = transform.position;
            }
        }

        public void Setup(BrickData data)
        {
            _data = data;
            
            _durability.Setup(data);
            _spriteHandler.Setup(data);
        }
    }
}