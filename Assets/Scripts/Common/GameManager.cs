using Common.Events;
using UnityEngine;

namespace Common
{
    public class GameManager : MonoBehaviour, IService
    {
        private int _level;

        private GameState _state = GameState.Idle;
        public GameState State
        {
            get => _state;
            set
            {
                if (value == _state)
                    return;

                var args = new GameStateChangedEventArgs(_state, _state = value, _level);
                GameStateChanged?.Invoke(args);
            }
        }

        public GameStateChangedEvent GameStateChanged;

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            State = GameState.Gameplay;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                State = GameState.GameOver;
            }
        }
    }
}