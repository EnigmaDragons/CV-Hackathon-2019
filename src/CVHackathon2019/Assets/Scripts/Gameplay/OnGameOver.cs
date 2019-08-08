using System.Linq;
using UnityEngine;

public class OnGameOver : MonoBehaviour
{
    public GameObject[] ToActivate;
    private bool _wasTriggered;
    
    public void Update()
    {
        if (!_wasTriggered && GameState.Current.IsGameOver)
        {
            _wasTriggered = true;
            ToActivate.ToList().ForEach(x => x.SetActive(true));
        }
    }
}
