using System;
using PowerUps;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Common
{
    public static class Services
    {
        private static GameManager _gameManager;
        private static PowerUpManager _powerUpManager;
        public static GameManager GameManager => _gameManager ??= FindOrThrow<GameManager>();
        public static PowerUpManager PowerUpManager => _powerUpManager ??= FindOrThrow<PowerUpManager>();
        
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
