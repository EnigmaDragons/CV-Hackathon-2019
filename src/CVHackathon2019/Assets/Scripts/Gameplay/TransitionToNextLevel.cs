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
        yield return new WaitForSeconds(DelayBeforeNextLevel);
        GameState.Reset();
        Application.LoadLevel(1);
    }
}
