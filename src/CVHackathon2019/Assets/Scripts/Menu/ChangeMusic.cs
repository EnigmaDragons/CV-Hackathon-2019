using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip Level1Music;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            source.clip = menuMusic;
            source.Play();
        }
        else if (level == 1)
        {
            source.clip = Level1Music;
            source.Play();
        }
    }
}