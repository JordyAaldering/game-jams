using UnityEngine;
using Newtonsoft.Json;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager instance { get; private set; }

    public string[] names_first { get; private set; }
    public string[] names_last { get; private set; }
    public string[] messagesPositive { get; private set; }
    public string[] messagesNegative { get; private set; }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        names_first = JsonConvert.DeserializeObject<string[]>(
            Resources.Load<TextAsset>("names_first").ToString());
        names_last = JsonConvert.DeserializeObject<string[]>(
            Resources.Load<TextAsset>("names_last").ToString());
        
        messagesPositive = JsonConvert.DeserializeObject<string[]>(
            Resources.Load<TextAsset>("messages_positive").ToString());
        messagesNegative = JsonConvert.DeserializeObject<string[]>(
            Resources.Load<TextAsset>("messages_negative").ToString());
    }
}
