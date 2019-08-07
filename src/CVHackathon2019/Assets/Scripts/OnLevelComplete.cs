using UnityEngine;

public class OnLevelComplete : MonoBehaviour
{
    public GameObject ToActivate;
    private bool _wasTriggered;
    
    void Update()
    {
        if (!_wasTriggered && GameState.Current.IsLevelComplete)
        {
            _wasTriggered = true;
            ToActivate.SetActive(true);
        }
    }
}
