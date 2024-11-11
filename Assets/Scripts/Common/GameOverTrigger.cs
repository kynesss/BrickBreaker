using Ball;
using UnityEngine;

namespace Common
{
    public class GameOverTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<BallMovement>())
                Services.GameManager.GameOver();
        }
    }
}
