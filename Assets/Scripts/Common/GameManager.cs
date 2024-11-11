using Common.Events;
using UnityEngine;

namespace Common
{
    public class GameManager : MonoBehaviour, IService
    {
        public static GameStateChangedEvent GameStateChanged;
    }
}