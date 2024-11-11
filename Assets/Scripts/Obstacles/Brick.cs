using UnityEngine;

namespace Obstacles
{
    public class Brick : MonoBehaviour
    {
        private BrickDurability _durability;
        private BrickSpriteHandler _spriteHandler;

        private void Awake()
        {
            _durability = GetComponent<BrickDurability>();
            _spriteHandler = GetComponent<BrickSpriteHandler>();
        }

        public void Setup(BrickData data)
        {
            _durability.Setup(data);
            _spriteHandler.Setup(data);
        }
    }
}