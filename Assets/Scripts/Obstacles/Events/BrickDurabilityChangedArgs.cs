namespace Obstacles.Events
{
    public class BrickDurabilityChangedArgs
    {
        public int LastDurability { get; private set; }
        public int CurrentDurability { get; private set; }

        public bool IsAlive => CurrentDurability > 0;
        public bool IsDead => CurrentDurability == 0;

        public BrickDurabilityChangedArgs(int lastDurability, int currentDurability)
        {
            LastDurability = lastDurability;
            CurrentDurability = currentDurability;
        }
    }
}