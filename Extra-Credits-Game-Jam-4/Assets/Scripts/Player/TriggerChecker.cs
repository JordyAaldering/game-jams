using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<IHittable>().OnHit();
    }
}
