namespace Common.Events
{
    public delegate void GameStateChangedEvent(GameState lastState, GameState newState);
}