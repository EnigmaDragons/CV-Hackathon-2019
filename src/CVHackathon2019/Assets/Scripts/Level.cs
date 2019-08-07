using UnityEngine;

public class Level : ScriptableObject
{
    public LevelOutcome LevelOutcome { get; set; }
    public int NumCustomersRequired { get; set; }
    public int NumCustomersServed { get; set; }
}
