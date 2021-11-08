#pragma warning disable 0649
using Extensions;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    
    [SerializeField] private Transform[] bgs;

    private void Update()
    {
        foreach (Transform bg in bgs)
        {
            bg.Translate(-speed * Time.deltaTime, 0f, 0f);
            
            Vector3 pos = bg.position;
            if (pos.x < -21f)
            {
                bg.position = pos.With(x: pos.x + 42f);
            }
        }
    }
}
