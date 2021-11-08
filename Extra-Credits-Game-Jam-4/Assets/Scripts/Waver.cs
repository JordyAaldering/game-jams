using Extensions;
using UnityEngine;

public class Waver : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float height = 0.5f;

    private float x;
    
    private void Start()
    {
        x = speed * height;
    }

    private void Update()
    {
        Transform t = transform;
        t.position = t.position.With(y: Mathf.Sin(x * Time.time));
    }
}
