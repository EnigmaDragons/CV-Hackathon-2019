using Assets.Scripts;
using UnityEngine;

public class OnGameOver : MonoBehaviour
{
    public GameObject ToActivate;
    private bool _wasTriggered;
    
    void Update()
    {
        if (!_wasTriggered && GameState.Current.IsGameOver)
        {
            _wasTriggered = true;
            ToActivate.SetActive(true);
        }
    }
}
