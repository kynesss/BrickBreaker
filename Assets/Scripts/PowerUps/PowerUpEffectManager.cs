using System.Collections.Concurrent;
using Common;
using UnityEngine;

namespace PowerUps
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

        public void AddEffect(PowerUpEffect effect)
        {
            if (_activeEffects.ContainsKey(effect))
            {
                _activeEffects[effect] = effect.Duration;
                return;
            }

            _activeEffects.TryAdd(effect, effect.Duration);
        }
    }
}