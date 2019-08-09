using UnityEngine;
using UnityEngine.UI;

public class MusicHandler : MonoBehaviour
{
    private static MusicHandler _instance;
    public static MusicHandler Instance => _instance;
    
    public AudioClip MenuMusic;
    public AudioClip Level1Music;
    public AudioClip VictoryMusic;
    private AudioSource source;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            source = GetComponent<AudioSource>();
        }
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            source.clip = MenuMusic;
            source.Play();
        }
        else if (level == 1)
        {
            source.clip = Level1Music;
            source.Play();
        }
        else if (level == 2)
        {
            source.clip = VictoryMusic;
            source.Play();
        }
    }
}