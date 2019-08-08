using UnityEngine;

    public class AudioClips: MonoBehaviour
    {
        public AudioSource AudioSource;
        public AudioClip CarLaunched;
        public AudioClip HaulerMoved;

        public void PlayHaulerMoved()
        {
            AudioSource.PlayOneShot(HaulerMoved);
        }

        public void PlayCarLaunched()
        {
            AudioSource.PlayOneShot(CarLaunched);
        }
    }