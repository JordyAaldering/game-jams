using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance { get; private set; }

    public Transform player1;
    public Transform player2;

    private AnimationSetter animationSetter1;
    private AnimationSetter animationSetter2;
    
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
        animationSetter1 = player1.GetComponent<AnimationSetter>();
        animationSetter2 = player2.GetComponent<AnimationSetter>();
    }

    public void AddToFearSetter(GameObject go)
    {
        animationSetter1.hittables.Add(go);
        animationSetter2.hittables.Add(go);
    }
    
    public void RemoveFromFearSetter(GameObject go)
    {
        animationSetter1.hittables.Remove(go);
        animationSetter2.hittables.Remove(go);
    }
}
