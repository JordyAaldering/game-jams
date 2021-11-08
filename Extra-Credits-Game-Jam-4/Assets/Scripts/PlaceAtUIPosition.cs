#pragma warning disable 0649
using Extensions;
using UnityEngine;

public class PlaceAtUIPosition : MonoBehaviour
{
    [SerializeField] private RectTransform target;
    [SerializeField] private Vector3 offset = Vector3.zero;

    private void Start()
    {
        Camera cam = Camera.main;
        if (cam != null)
        {
            transform.position = cam.ScreenToWorldPoint(target.position).With(z: 0f) + offset;
        }
    }
}
