using Audio;
using UnityEngine;

namespace Player
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float lifetime = 5f;

        private void Start()
        {
            GetComponent<Rigidbody>().velocity = speed * transform.forward;
        }

        private void Update()
        {
            if (lifetime > 0f)
            {
                lifetime -= Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            GameObject go = other.gameObject;
            if (go.CompareTag("WallGlass"))
            {
                AudioManager.instance.PlayEffect(AudioManager.instance.glassBreakClip);
                
                Destroy(go);
                Destroy(gameObject);
            }
        }
    }
}
