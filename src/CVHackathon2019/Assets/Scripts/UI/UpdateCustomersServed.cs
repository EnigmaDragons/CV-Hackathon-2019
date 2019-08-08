using TMPro;
using UnityEngine;

public class UpdateCustomersServed : MonoBehaviour
{
    private TextMeshProUGUI _text;
    
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _text.text = GameState.Current.NumCustomersServed.ToString();
    }
}
