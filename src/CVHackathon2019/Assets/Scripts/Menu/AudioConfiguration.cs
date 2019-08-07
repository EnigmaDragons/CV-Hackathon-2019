using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    public class AudioConfiguration : MonoBehaviour
    {
        public AudioMixer Mixer;
        public string AudioGroup;

        public void AdjustVolume(float volume)
        {
            Mixer.SetFloat(AudioGroup, volume);
        }
    }
}