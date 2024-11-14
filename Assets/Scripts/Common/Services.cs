using System;
using PowerUps;
using PowerUps.Effects;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Common
{
    public static class Services
    {
        private static GameManager _gameManager;
        private static PowerUpSpawner _powerUpSpawner;
        private static PowerUpEffectManager _powerUpEffectManager;
        public static GameManager GameManager => _gameManager ??= FindOrThrow<GameManager>();
        public static PowerUpSpawner PowerUpSpawner => _powerUpSpawner ??= FindOrThrow<PowerUpSpawner>();

        public static PowerUpEffectManager PowerUpEffectManager =>
            _powerUpEffectManager ??= FindOrThrow<PowerUpEffectManager>();
        
        private static T FindOrThrow<T>() where T : MonoBehaviour, IService
        {
            var service = Object.FindObjectOfType<T>();

            if (service == null)
            {
                throw new NullReferenceException($"Service of type {typeof(T).Name} does not exist");
            }
            
            return service;
        }
    }
}
