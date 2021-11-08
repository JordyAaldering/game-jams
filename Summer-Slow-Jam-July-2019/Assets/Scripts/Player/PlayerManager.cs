using Audio;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private Transform player;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            if (player.position.y < -10)
            {
                Die();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            GameObject go = other.gameObject;
            if (go.CompareTag("Wall") || go.CompareTag("WallGlass"))
            {
                Die();
            }
        }

        private void Die()
        {
            AudioManager.instance.PlayEffect(AudioManager.instance.dieClip);
            
            FindObjectOfType<GameMenu>().GameOver();

            enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Spike"))
            {
                Die();
            }
            else if (other.CompareTag("End"))
            {
                AudioManager.instance.PlayEffect(AudioManager.instance.winClip);
                
                FindObjectOfType<GameMenu>().LevelComplete();
            }
        }
    }
}
