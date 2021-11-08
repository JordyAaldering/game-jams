#pragma warning disable 0649
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance { get; private set; }

        [SerializeField] private AudioSource sfxSource;

        public AudioClip jumpClip;
        public AudioClip slideClip;
        public AudioClip dieClip;
        public AudioClip winClip;
        public AudioClip glassBreakClip;

        private void Awake()
        {
            if (!instance)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void PlayEffect(AudioClip effect)
        {
            sfxSource.pitch = Random.Range(0.95f, 1.05f);
            sfxSource.PlayOneShot(effect);
        }
    }
}
