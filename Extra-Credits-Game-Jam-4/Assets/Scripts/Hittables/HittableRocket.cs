#pragma warning disable 0649
using UnityEngine;

public class HittableRocket : MonoBehaviour, IHittable
{
    [SerializeField] private GameObject destroyEffect;
    
    public void OnHit()
    {
        GameOverManager.instance.gameOver = true;

        AudioController.instance.HitThumb();
        
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
