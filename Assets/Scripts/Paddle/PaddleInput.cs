using UnityEngine;

namespace Paddle
{
    public class PaddleInput : MonoBehaviour
    {
        [SerializeField] private KeyCode leftKeyCode = KeyCode.A;
        [SerializeField] private KeyCode rightKeyCode = KeyCode.D;

        private Vector2 _axis;
        
        private void Update()
        {
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

        public Vector3 GetAxis()
        {
            return _axis;
        }
    }
}