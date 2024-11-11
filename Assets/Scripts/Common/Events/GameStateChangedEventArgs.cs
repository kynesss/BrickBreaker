namespace Common.Events
{
    public class GameStateChangedEventArgs
    {
        public GameState LastState { get; private set; }
        public GameState NewState { get; private set; }
        public int CurrentLevel { get; private set; }

        public GameStateChangedEventArgs(GameState lastState, GameState newState, int currentLevel)
        {
            LastState = lastState;
            NewState = newState;
            CurrentLevel = currentLevel;
        }
    }
}