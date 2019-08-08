using System;
using System.Linq;
using UnityEngine;

public sealed class GameState
{
    private static bool _initialied = false;
    private int _levelIndex;
    private readonly LevelObj _levelsObj;
    private LevelConfig _levelConfig => _levelsObj?.Levels[_levelIndex];

    public int NumCustomersServed { get; private set; }
    public int StarRatings { get; private set; } = 5;

    public LevelOutcome Outcome { get; private set; } = LevelOutcome.Incomplete;
    public bool IsGameOver => Outcome == LevelOutcome.GameOver;
    public bool IsGameInProgres => Outcome == LevelOutcome.Incomplete;
    public bool IsLevelComplete => Outcome == LevelOutcome.Complete;

    public float CustomerSpeed => _levelConfig?.CustomerSpeed ?? 0.0f;
    public float CustomerSpawnInterval => _levelConfig?.CustomerSpawnInterval ?? 1f;
    public int CarReturnRate { get; private set; } = 0;
    public int NumCustomersRequired => _levelConfig?.NumCustomersRequired ?? int.MaxValue;

    public int GameScore = 0;

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

    public static void Reset()
    {
        if (!_initialied)
            Current = new GameState();
        else
        {
            var lvlObj = Current._levelsObj;
            Current = new GameState(lvlObj);
        }
    }

    public static void Init(LevelObj levels)
    {
        if (!_initialied)
        {
            Current = new GameState(levels);
            _initialied = true;
            Debug.Log("Initialized Game State");
        }
    }

    private GameState()
    {
        Debug.Log("==============Reset===============");
    }

    private GameState(LevelObj levelsObj)
    {
        _levelIndex = 0;
        _levelsObj = levelsObj;
        CarReturnRate = _levelConfig.CarReturnRate;
        Debug.Log("Level Count: " + levelsObj.Levels + ", NumRequired: " + (levelsObj?.Levels.First()?.NumCustomersRequired ?? -99));
    }

    public static void NextLevel()
    {
        Current._levelIndex++;
        Current.Outcome = LevelOutcome.Incomplete;
        Current.NumCustomersServed = 0;
        Current.StarRatings = 5;
        Current.CarReturnRate = Current._levelConfig.CarReturnRate;
        Debug.Log("Next Level! Index: " + Current._levelIndex);
    }

    public static bool HasNextLevel()
    {
        var hasNextLevel = Current._levelIndex < (Current?._levelsObj?.Levels?.Length - 1 ?? 0);
        Debug.Log("Level Index: " + Current._levelIndex + ", Levels Length: " + Current._levelsObj.Levels.Length + "Has Next: " + hasNextLevel);
        return hasNextLevel;
    }

    public static void SetReturnRate(int i)
    {
        Current.CarReturnRate = i;
    }
}

public enum LevelOutcome
{
    Incomplete,
    GameOver,
    Complete
}
