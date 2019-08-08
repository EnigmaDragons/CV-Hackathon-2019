using UnityEngine;

public sealed class GameState
{
    public bool IsGameOver => Outcome == LevelOutcome.GameOver;
    public bool IsLevelComplete => Outcome == LevelOutcome.Complete;
    public LevelOutcome Outcome { get; private set; } = LevelOutcome.Incomplete;
    public int NumCustomersServed { get; private set; } = 0;
    public int NumCustomersRequired { get; private set; } = 10;
    public int StarRatings { get; private set; } = 5;

    public void DecreaseStarRating()
    {
        StarRatings -= 1;
        if (StarRatings > 0) return;

        Outcome = LevelOutcome.GameOver;
        Debug.Log("Game Over");
    }

    public void SetLevelOutcome(LevelOutcome outcome)
    {
        if (Outcome == LevelOutcome.Incomplete)
        {
            Debug.Log($"{outcome}");
            Outcome = outcome;
        }
    }
    
    public void OnCustomerServed()
    {
        NumCustomersServed++;
        if (NumCustomersServed >= NumCustomersRequired)
            Outcome = LevelOutcome.Complete;
        Debug.Log($"{NumCustomersServed} / {NumCustomersRequired}");
    }

    public static GameState Current = new GameState();
    public static void Reset() => Current = new GameState();
    private GameState() {}
}

public enum LevelOutcome
{
    Incomplete,
    GameOver,
    Complete
}
