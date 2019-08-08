using System.Linq;
using UnityEngine;

public class OnLevelComplete : MonoBehaviour
{
    public GameObject[] ToActivate;
    private bool _wasTriggered;
    
    public void Update()
    {
        if (!_wasTriggered && GameState.Current.IsLevelComplete)
        {
            _wasTriggered = true;
            Debug.Log($"Activating {ToActivate.Length} Items");
            ToActivate.ToList().ForEach(x => x.SetActive(true));
        }
    }
}
