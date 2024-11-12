using Common;
using Common.Events;
using UnityEngine;

namespace PaddleStuff
{
    public class PaddleInput : MonoBehaviour
    {
        [SerializeField] private KeyCode leftKeyCode = KeyCode.A;
        [SerializeField] private KeyCode rightKeyCode = KeyCode.D;

        private Vector2 _axis;
        private bool _isBlocked;

        private void OnEnable()
        {
            Services.GameManager.GameStateChanged += OnGameStateChanged;
        }

        private void OnDisable()
        {
            Services.GameManager.GameStateChanged -= OnGameStateChanged;
        }

        private void Update()
        {
            if (_isBlocked)
                return;
            
            SetAxis();
        }

        private void SetAxis()
        {
            if (Input.GetKey(leftKeyCode))
                _axis = Vector2.left;
            else if (Input.GetKey(rightKeyCode))
                _axis = Vector2.right;
            else
                _axis = Vector2.zero;
        }

        private void OnGameStateChanged(GameStateChangedEventArgs args)
        {
            _isBlocked = args.NewState != GameState.Gameplay;
            _axis = Vector2.zero;
        }

        public Vector3 GetAxis()
        {
            return _axis;
        }
    }
}