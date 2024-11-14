using NaughtyAttributes;
using UnityEngine;

namespace PowerUps.Effects
{
    public abstract class PowerUpEffect : ScriptableObject
    {
        [field: SerializeField]
        [field: BoxGroup("Base")]
        public Sprite Icon { get; private set; }

        [field: SerializeField]
        [field: BoxGroup("Base")]
        public float Duration { get; private set; }
        
        [field: SerializeField]
        [field: BoxGroup("Base")]
        public PowerUpEffectType Type { get; private set; }

        public abstract bool TryApply(GameObject target);
        public abstract void Remove();
    }
}