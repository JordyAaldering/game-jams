using Extensions;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float width = 0.5f;

    private Vector3 original;
    private float x;

    private void Start()
    {
        original = transform.localPosition;
        x = speed * width;
    }

    private void Update()
    {
        Transform t = transform;
        t.localPosition = t.localPosition.With(x: original.x + Mathf.Sin(x * Time.time));
    }
}
