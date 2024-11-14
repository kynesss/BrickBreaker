using System.Collections.Concurrent;
using System.Linq;
using Common;
using UnityEngine;

namespace PowerUps.Effects
{
    public class PowerUpEffectManager : MonoBehaviour, IService
    {
        private readonly ConcurrentDictionary<PowerUpEffect, float> _activeEffects = new();

        private void Update()
        {
            ProcessEffects();
        }

        private void ProcessEffects()
        {
            foreach (var effect in _activeEffects.Keys)
            {
                if (_activeEffects[effect] > 0f)
                {
                    _activeEffects[effect] -= Time.deltaTime;
                }
                else
                {
                    RemoveEffect(effect);
                }
            }
        }

        private void RemoveEffect(PowerUpEffect effect)
        {
            effect.Remove();
            _activeEffects.TryRemove(effect, out _);
        }

        public void RemoveAllEffects()
        {
            foreach (var effect in _activeEffects.Keys)
            {
                RemoveEffect(effect);
            }

            _activeEffects.Clear();
        }

        public void AddOrUpdateEffect(PowerUpEffect effect)
        {
            var existingEffect = _activeEffects.Keys.FirstOrDefault(x => x.Type == effect.Type);

            if (existingEffect != null)
            {
                _activeEffects[existingEffect] = effect.Duration;
            }
            else
            {
                _activeEffects.TryAdd(effect, effect.Duration);
            }
        }
    }
}