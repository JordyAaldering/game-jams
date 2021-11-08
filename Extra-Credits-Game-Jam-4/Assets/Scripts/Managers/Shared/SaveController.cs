using UnityEngine;

public class SaveController : MonoBehaviour
{
    public static int facebookScore
    {
        get => PlayerPrefs.GetInt("facebookScore", 0);
        set => PlayerPrefs.SetInt("facebookScore", value);
    }
    
    public static int redditScore
    {
        get => PlayerPrefs.GetInt("redditScore", 0);
        set => PlayerPrefs.SetInt("redditScore", value);
    }
    
    public static int snapchatScore
    {
        get => PlayerPrefs.GetInt("snapchatScore", 0);
        set => PlayerPrefs.SetInt("snapchatScore", value);
    }
    
    public static int twitterScore
    {
        get => PlayerPrefs.GetInt("twitterScore", 0);
        set => PlayerPrefs.SetInt("twitterScore", value);
    }
}
