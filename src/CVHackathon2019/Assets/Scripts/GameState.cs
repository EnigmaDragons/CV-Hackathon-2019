public sealed class GameState
{
    public bool IsGameOver => Outcome == LevelOutcome.GameOver;
    public bool IsLevelComplete => Outcome == LevelOutcome.Complete;
    public LevelOutcome Outcome { get; set; } = LevelOutcome.Incomplete;
    public int NumCustomersServed { get; private set; }
    public int NumCustomersRequired { get; private set; }
    
    public void OnCustomerServed()
    {
        NumCustomersServed++;
        if (NumCustomersServed >= NumCustomersRequired)
            Outcome = LevelOutcome.Complete;
    }
    
    public static GameState Current = new GameState();
    public void Reset() => Current = new GameState();
    private GameState() {}
}

public enum LevelOutcome
{
    Incomplete,
    GameOver,
    Complete
}
