using UnityEngine;

public class LevelObj : MonoBehaviour
{
    public LevelConfig[] Levels;
    
    public void Start()
    {
        GameState.Init(this);
    }
}