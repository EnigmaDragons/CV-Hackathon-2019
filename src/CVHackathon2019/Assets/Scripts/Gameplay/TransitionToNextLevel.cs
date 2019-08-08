using System.Collections;
using UnityEngine;

public class TransitionToNextLevel : MonoBehaviour
{
    public float DelayBeforeNextLevel = 2;
    public LevelConfig[] Levels;
    
    void Start()
    {
        StartCoroutine(NavigateToNextLevel());
    }

    private IEnumerator NavigateToNextLevel()
    {
        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(DelayBeforeNextLevel);
        if (GameState.HasNextLevel())
        {
            Application.LoadLevel(1);
            GameState.NextLevel();
        }
        else
        {
            // TODO: You Win!
            Application.LoadLevel(0);
        }
        Time.timeScale = 1.0f;
    }
}
