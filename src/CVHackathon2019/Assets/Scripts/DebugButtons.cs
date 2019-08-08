using UnityEngine;

public class DebugButtons : MonoBehaviour
{
    private bool _wasTriggered;
    
    public void Update()
    {
        if (!_wasTriggered && Input.GetButton("Fire2"))
        {
            _wasTriggered = true;
            Debug.Log("Triggered Debug Level Complete");
            GameState.Current.SetLevelOutcome(LevelOutcome.Complete);
        }
    }
}
