using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public int StartingLevelId = 1;
    
    public void Go()
    {
        GameState.Reset();
        Debug.Log("Reset Game Requested");
        Application.LoadLevel(StartingLevelId);
    }
}
