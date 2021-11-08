#pragma warning disable 0649
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance { get; private set; }

    [SerializeField] private AudioSource sfxSource;

    [SerializeField] private AudioClip positiveText;
    [SerializeField] private AudioClip negativeText;
    [SerializeField] private AudioClip thumbsDown;
    [SerializeField] private AudioClip upgradePurchased;
    [SerializeField] private AudioClip upgradeFailed;
    [SerializeField] private AudioClip select;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void HitText(bool positive)
    {
        Play(positive ? positiveText : negativeText);
    }

    public void HitThumb()
    {
        Play(thumbsDown);
    }

    public void PurchasedUpgrade(bool successful)
    {
        Play(successful ? upgradePurchased : upgradeFailed);
    }

    public void Select()
    {
        Play(@select);
    }

    private void Play(AudioClip clip)
    {
        sfxSource.pitch = Random.Range(0.95f, 1.05f);
        sfxSource.PlayOneShot(clip);
    }
}
