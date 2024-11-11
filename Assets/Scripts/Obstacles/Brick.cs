using System;
using UnityEngine;

namespace Obstacles
{
    public class Brick : MonoBehaviour
    {
        [SerializeField] private BrickData dummyData;
        
        private BrickDurability _durability;
        private BrickSpriteHandler _spriteHandler;

        private void Awake()
        {
            _durability = GetComponent<BrickDurability>();
            _spriteHandler = GetComponent<BrickSpriteHandler>();
        }

        private void Start()
        {
            Setup(dummyData);
        }

        public void Setup(BrickData data)
        {
            _durability.Setup(data);
            _spriteHandler.Setup(data);
        }
    }
}