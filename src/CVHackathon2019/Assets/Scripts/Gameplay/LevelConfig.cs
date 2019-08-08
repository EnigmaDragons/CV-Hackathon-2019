using UnityEngine;

[CreateAssetMenu(menuName = "LevelConfig")]
public class LevelConfig : ScriptableObject
{
    public float CustomerSpeed;
    public float CustomerSpawnInterval;
    public int CarReturnRate;
    public int NumCustomersRequired;
    
    public int Level { get; set; }
}
