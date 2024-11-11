namespace Common.Events
{
    public class GameStateChangedEventArgs
    {
        public GameState LastState { get; private set; }
        public GameState NewState { get; private set; }

        public GameStateChangedEventArgs(GameState lastState, GameState newState)
        {
            LastState = lastState;
            NewState = newState;
        }
    }
}