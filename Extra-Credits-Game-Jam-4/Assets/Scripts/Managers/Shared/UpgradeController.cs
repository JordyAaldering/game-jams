using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public static float facebookPositiveBonus
    {
        get => PlayerPrefs.GetFloat("facebookPositiveBonus", 0f);
        set => PlayerPrefs.SetFloat("facebookPositiveBonus", value);
    }
    
    public static float redditPositiveBonus
    {
        get => PlayerPrefs.GetFloat("redditPositiveBonus", 0f);
        set => PlayerPrefs.SetFloat("redditPositiveBonus", value);
    }
    
    public static float snapchatPositiveBonus
    {
        get => PlayerPrefs.GetFloat("snapchatPositiveBonus", 0f);
        set => PlayerPrefs.SetFloat("snapchatPositiveBonus", value);
    }
    
    public static float twitterPositiveBonus
    {
        get => PlayerPrefs.GetFloat("twitterPositiveBonus", 0f);
        set => PlayerPrefs.SetFloat("twitterPositiveBonus", value);
    }
    
    
    public static int facebookScoreAmount
    {
        get => PlayerPrefs.GetInt("facebookScoreAmount", 1);
        set => PlayerPrefs.SetInt("facebookScoreAmount", value);
    }
    
    public static int redditScoreAmount
    {
        get => PlayerPrefs.GetInt("redditScoreAmount", 1);
        set => PlayerPrefs.SetInt("redditScoreAmount", value);
    }
    
    public static int snapchatScoreAmount
    {
        get => PlayerPrefs.GetInt("snapchatScoreAmount", 1);
        set => PlayerPrefs.SetInt("snapchatScoreAmount", value);
    }
    
    public static int twitterScoreAmount
    {
        get => PlayerPrefs.GetInt("twitterScoreAmount", 1);
        set => PlayerPrefs.SetInt("twitterScoreAmount", value);
    }
    
    
    public static float dragSpeedBonus
    {
        get => PlayerPrefs.GetFloat("dragSpeedBonus", 0f);
        set => PlayerPrefs.SetFloat("dragSpeedBonus", value);
    }
    
    public static float dragDistanceBonus
    {
        get => PlayerPrefs.GetFloat("dragDistanceBonus", 0f);
        set => PlayerPrefs.SetFloat("dragDistanceBonus", value);
    }
}
