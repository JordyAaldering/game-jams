#pragma warning disable 0649
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class HittableText : MonoBehaviour, IHittable
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI messageText;

    [SerializeField] private Sprite facebookSprite;
    [SerializeField] private Sprite redditSprite;
    [SerializeField] private Sprite snapchatSprite;
    [SerializeField] private Sprite twitterSprite;
    
    [SerializeField] private GameObject[] destroyEffectsPositive;
    [SerializeField] private GameObject destroyEffectNegative;
    
    private TextBox _textBox;
    public TextBox textBox
    {
        get => _textBox;
        set
        {
            _textBox = value;
            SetText();
            SetSprite();
        }
    }

    private void SetText()
    {
        string first = ResourcesManager.instance.names_first[
            Random.Range(0, ResourcesManager.instance.names_first.Length)];
        string last = ResourcesManager.instance.names_last[
            Random.Range(0, ResourcesManager.instance.names_last.Length)];
        nameText.text = $"{first} {last}";

        messageText.text = textBox.isPositive
            ? ResourcesManager.instance.messagesPositive[
                Random.Range(0, ResourcesManager.instance.messagesPositive.Length)]
            : ResourcesManager.instance.messagesNegative[
                Random.Range(0, ResourcesManager.instance.messagesNegative.Length)];
    }

    private void SetSprite()
    {
        GetComponent<SpriteRenderer>().sprite =
            textBox.platform == Platform.Facebook ? facebookSprite :
            textBox.platform == Platform.Reddit ? redditSprite :
            textBox.platform == Platform.Snapchat ? snapchatSprite :
            twitterSprite;
    }

    public void OnHit()
    {
        if (textBox.isPositive)
        {
            Instantiate(
                destroyEffectsPositive[Random.Range(0, destroyEffectsPositive.Length)],
                transform.position,
                Quaternion.identity);
            
            ScoreManager.instance.AddScore(textBox.platform);
        }
        else
        {
            Instantiate(destroyEffectNegative, transform.position, Quaternion.identity);
            GameOverManager.instance.gameOver = true;
        }
        
        AudioController.instance.HitText(textBox.isPositive);
        PlayerManager.instance.RemoveFromFearSetter(gameObject);
        Destroy(gameObject);
    }
}
