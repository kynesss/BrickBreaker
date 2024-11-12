using System;
using UnityEngine;

namespace Ball
{
    public class BallCollision : MonoBehaviour
    {
        [SerializeField] private int bounceThreshold = 10;

        private int _bounceCounter;
        
        public event Action BounceThresholdReached; 
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            _bounceCounter++;

            if (_bounceCounter != bounceThreshold) 
                return;
            
            OnBounceCounterReached();
        }

        private void OnBounceCounterReached()
        {
            _bounceCounter = 0;
            BounceThresholdReached?.Invoke();
        }
    }
}