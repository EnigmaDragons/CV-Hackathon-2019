using System.Collections;
using UnityEngine;

public class TransitionToNextLevel : MonoBehaviour
{
    public float DelayBeforeNextLevel = 2;

    void Start()
    {
        StartCoroutine(NavigateToNextLevel());
    }

    private IEnumerator NavigateToNextLevel()
    {
        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(DelayBeforeNextLevel);
        if (!GameState.HasNextLevel())
            Application.LoadLevel(2); // Credits
        else
        {
            Application.LoadLevel(1);
            GameState.NextLevel();
        }

        Time.timeScale = 1.0f;
    }
}