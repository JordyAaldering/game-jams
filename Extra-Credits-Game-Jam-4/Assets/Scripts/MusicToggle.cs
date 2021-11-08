#pragma warning disable 0649
using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    [SerializeField] private Sprite muteIcon;
    [SerializeField] private Sprite unmuteIcon;
    
    private AudioSource musicSource;
    private Image toggleImage;

    private void Start()
    {
        musicSource = GameObject.Find("AudioController").GetComponent<AudioSource>();
        toggleImage = GetComponent<Image>();
    }

    public void ToggleMusic()
    {
        bool e = !musicSource.enabled;
        musicSource.enabled = e;
        toggleImage.sprite = e ? muteIcon : unmuteIcon;
    }
}
