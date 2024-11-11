using UnityEngine;

namespace Paddle
{
    [RequireComponent(typeof(PaddleInput))]
    public class PaddleMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 50f;
        [SerializeField] private float movementRange = 17.53124f;

        private PaddleInput _input;

        private void Awake()
        {
            _input = GetComponent<PaddleInput>();
        }

        private void Update()
        {
            MovePaddle();
            ClampPosition();
        }

        private void MovePaddle()
        {
            transform.position += _input.GetAxis() * (speed * Time.deltaTime);
        }

        private void ClampPosition()
        {
            var position = transform.position;
            var x = Mathf.Clamp(position.x, -movementRange, movementRange);
            transform.position = new Vector3(x, position.y, position.z);
        }
    }
}
