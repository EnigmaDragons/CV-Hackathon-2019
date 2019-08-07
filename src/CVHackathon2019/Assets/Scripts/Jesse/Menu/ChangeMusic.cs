using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 2)
        {
            source.clip = menuMusic;
            source.Play();
        }
        else if (level == 2)
        {
            source.clip = gameMusic;
            source.Play();
        }
    }
}