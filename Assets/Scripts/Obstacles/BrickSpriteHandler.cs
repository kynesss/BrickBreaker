using Obstacles.Events;
using UnityEngine;

namespace Obstacles
{
    public class BrickSpriteHandler : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private Sprite _hitIcon;
        
        private BrickDurability _durability;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _durability = GetComponent<BrickDurability>();
        }

        private void OnEnable()
        {
            _durability.Changed += OnDurabilityChanged;
        }

        private void OnDisable()
        {
            _durability.Changed -= OnDurabilityChanged;
        }

        private void SetIcon(Sprite icon)
        {
            _spriteRenderer.sprite = icon;
        }

        private void OnDurabilityChanged(BrickDurabilityChangedArgs args)
        {
            if (args.CurrentDurability == 1)
            {
                SetIcon(_hitIcon);
            }
        }

        public void Setup(BrickData data)
        {
            SetIcon(data.Icon);
            _hitIcon = data.HitIcon;
        }
    }
}