using System.Collections;
using UnityEngine;

public class AnimSprites : MonoBehaviour
{
    public Sprite[] Sprites;
    public float BetweenSeconds = 0.2f;
    private SpriteRenderer _sprites;
    private int _index = 0;

    void Start()
    {
        _sprites = GetComponent<SpriteRenderer>();
        StartCoroutine(Go());
    }

    public IEnumerator Go()
    {
        while (_index < Sprites.Length)
        {
            _sprites.sprite = Sprites[_index];
            yield return new WaitForSeconds(BetweenSeconds);
            _index++;
        }
        Destroy(gameObject);
    }
}
