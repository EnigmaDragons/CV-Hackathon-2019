using TMPro;
using UnityEngine;

public class OnLevelStart : MonoBehaviour
{
    public GameObject Text;
    private bool _wasTriggered;

    public void Update()
    {
        if (!_wasTriggered && GameState.Current.IsGameInProgres)
        {
            var textComponent = Text.GetComponent<TextMeshProUGUI>();
            textComponent.text = $"Level {GameState.Current.Level}";
            Text.SetActive(true);
        }
    }
}