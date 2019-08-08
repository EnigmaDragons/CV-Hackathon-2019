using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip CarLaunched;
    public AudioClip HaulerMoved;
    public AudioClip HaulerLoaded;
    public AudioClip CustomerServed;

    public void PlayHaulerMoved()
    {
        AudioSource.PlayOneShot(HaulerMoved);
    }

    public void PlayCarLaunched()
    {
        AudioSource.PlayOneShot(CarLaunched);
    }

    public void PlayHaulerLoaded()
    {
        AudioSource.PlayOneShot(HaulerLoaded);
    }

    public void PlayCustomerServed()
    {
        AudioSource.PlayOneShot(CustomerServed);
    }
}