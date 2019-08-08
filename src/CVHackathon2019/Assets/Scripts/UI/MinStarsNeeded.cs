using UnityEngine;
using UnityEngine.UI;

public class MinStarsNeeded : MonoBehaviour
{
    public int MinStars = 1;

    private Image _image;
    
    void Start()
    {
        _image = GetComponent<Image>();
    }

    void Update()
    {
        _image.enabled = GameState.Current.StarRatings >= MinStars;
    }
}
