using Common.Events;
using UnityEngine;

namespace Common
{
    public class GameManager : MonoBehaviour, IService
    {
        private GameState _state = GameState.Starting;
        public GameState State
        {
            get => _state;
            set
            {
                if (value == _state)
                    return;
                
                GameStateChanged?.Invoke(_state, _state = value);
            }
        }

        public GameStateChangedEvent GameStateChanged;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                State = GameState.Gameplay;
            }
        }
    }
}