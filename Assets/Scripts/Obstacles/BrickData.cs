using UnityEngine;

namespace Obstacles
{
    [CreateAssetMenu(menuName = "Obstacles/Brick", fileName = "Brick")]
    public class BrickData : ScriptableObject
    {
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public Sprite HitIcon { get; private set; }
        [field: SerializeField][field: Min(1)] public int Durability { get; private set; }

        private void OnValidate()
        {
            if (Durability < 1)
                Durability = 1;
        }
    }
}