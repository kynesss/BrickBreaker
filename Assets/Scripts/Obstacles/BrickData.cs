using NaughtyAttributes;
using UnityEngine;

namespace Obstacles
{
    [CreateAssetMenu(menuName = "Obstacles/Brick", fileName = "Brick")]
    public class BrickData : ScriptableObject
    {
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public Sprite HitIcon { get; private set; }

        [field: SerializeField] public bool Destructible { get; private set; } = true;

        [field: SerializeField]
        [field: Min(1)]
        [field: EnableIf("Destructible")]
        public int Durability { get; private set; }
    }
}