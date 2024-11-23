using System.Linq;
using UnityEngine;
using Utils;

namespace PowerUps.Effects
{
    public class PowerUpEffectFactory : MonoBehaviour
    {
        [SerializeField] private PowerUpEffect[] powerUpEffects;
        
        public PowerUpEffect GetRandomPowerUpEffect()
        {
            return powerUpEffects[Random.Range(0, powerUpEffects.Length)];
        }

        public PowerUpEffect GetRandomPowerUpByDropChance()
        {
            var dropChanceSum = powerUpEffects.Sum(x => x.DropChance);
            var random = Random.Range(1, dropChanceSum + 1);

            var dropChancePrefixes = powerUpEffects.Select(x => x.DropChance)
                .ToArray()
                .GetSumPrefixesArray();

            var powerUpIndex = dropChancePrefixes.GetIndexInRange(random);
            return powerUpEffects[powerUpIndex];
        }
    }
}