using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeManager : MonoBehaviour
{
    public void PurchasePositiveBonus(int platform)
    {
        switch (platform)
        {
            case 0:
                if (SaveController.facebookScore >= 10)
                {
                    SaveController.facebookScore -= 10;
                    UpgradeController.facebookPositiveBonus += 0.05f;
                    ScoreManager.instance.PlayParticle(Platform.Facebook);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
            
            case 1:
                if (SaveController.redditScore >= 10)
                {
                    SaveController.redditScore -= 10;
                    UpgradeController.redditPositiveBonus += 0.05f;
                    ScoreManager.instance.PlayParticle(Platform.Reddit);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
            
            case 2:
                if (SaveController.snapchatScore >= 10)
                {
                    SaveController.snapchatScore -= 10;
                    UpgradeController.snapchatPositiveBonus += 0.05f;
                    ScoreManager.instance.PlayParticle(Platform.Snapchat);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
            
            case 3:
                if (SaveController.twitterScore >= 10)
                {
                    SaveController.twitterScore -= 10;
                    UpgradeController.twitterPositiveBonus += 0.05f;
                    ScoreManager.instance.PlayParticle(Platform.Twitter);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
        }
        
        ScoreManager.instance.UpdateScores();
    }
    
    public void PurchaseScoreAmount(int platform)
    {
        switch (platform)
        {
            case 0:
                if (SaveController.facebookScore >= 20)
                {
                    SaveController.facebookScore -= 20;
                    UpgradeController.facebookScoreAmount += 1;
                    ScoreManager.instance.PlayParticle(Platform.Facebook);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
            
            case 1:
                if (SaveController.redditScore >= 20)
                {
                    SaveController.redditScore -= 20;
                    UpgradeController.redditScoreAmount += 1;
                    ScoreManager.instance.PlayParticle(Platform.Reddit);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
            
            case 2:
                if (SaveController.snapchatScore >= 20)
                {
                    SaveController.snapchatScore -= 20;
                    UpgradeController.snapchatScoreAmount += 1;
                    ScoreManager.instance.PlayParticle(Platform.Snapchat);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
            
            case 3:
                if (SaveController.twitterScore >= 20)
                {
                    SaveController.twitterScore -= 20;
                    UpgradeController.twitterScoreAmount += 1;
                    ScoreManager.instance.PlayParticle(Platform.Twitter);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
        }
        
        ScoreManager.instance.UpdateScores();
    }
    
    public void PurchaseDragSpeedBonus(int platform)
    {
        switch (platform)
        {
            case 0:
                if (SaveController.facebookScore >= 5)
                {
                    SaveController.facebookScore -= 5;
                    UpgradeController.dragSpeedBonus += 0.03f;
                    ScoreManager.instance.PlayParticle(Platform.Facebook);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
            
            case 1:
                if (SaveController.redditScore >= 5)
                {
                    SaveController.redditScore -= 5;
                    UpgradeController.dragSpeedBonus += 0.03f;
                    ScoreManager.instance.PlayParticle(Platform.Reddit);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
            
            case 2:
                if (SaveController.snapchatScore >= 5)
                {
                    SaveController.snapchatScore -= 5;
                    UpgradeController.dragSpeedBonus += 0.03f;
                    ScoreManager.instance.PlayParticle(Platform.Snapchat);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
            
            case 3:
                if (SaveController.twitterScore >= 5)
                {
                    SaveController.twitterScore -= 5;
                    UpgradeController.dragSpeedBonus += 0.03f;
                    ScoreManager.instance.PlayParticle(Platform.Twitter);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
        }
        
        ScoreManager.instance.UpdateScores();
    }
    
    public void PurchaseDragDistanceBonus(int platform)
    {
        switch (platform)
        {
            case 0:
                if (SaveController.facebookScore >= 5)
                {
                    SaveController.facebookScore -= 5;
                    UpgradeController.dragDistanceBonus += 0.1f;
                    ScoreManager.instance.PlayParticle(Platform.Facebook);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
            
            case 1:
                if (SaveController.redditScore >= 5)
                {
                    SaveController.redditScore -= 5;
                    UpgradeController.dragDistanceBonus += 0.1f;
                    ScoreManager.instance.PlayParticle(Platform.Reddit);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
            
            case 2:
                if (SaveController.snapchatScore >= 5)
                {
                    SaveController.snapchatScore -= 5;
                    UpgradeController.dragDistanceBonus += 0.1f;
                    ScoreManager.instance.PlayParticle(Platform.Snapchat);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
            
            case 3:
                if (SaveController.twitterScore >= 5)
                {
                    SaveController.twitterScore -= 5;
                    UpgradeController.dragDistanceBonus += 0.1f;
                    ScoreManager.instance.PlayParticle(Platform.Twitter);
                    AudioController.instance.PurchasedUpgrade(true);
                    break;
                }

                StartCoroutine(Shake());
                AudioController.instance.PurchasedUpgrade(false);
                break;
        }
        
        ScoreManager.instance.UpdateScores();
    }

    private static IEnumerator Shake()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;
        Vector3 origin = go.transform.localPosition;
        
        Shaker shaker = go.GetComponent<Shaker>();
        shaker.enabled = true;
        
        yield return new WaitForSeconds(1f);

        // ReSharper disable once Unity.InefficientPropertyAccess
        shaker.enabled = false;
        go.transform.localPosition = origin;
    }
}
