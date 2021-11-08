#pragma warning disable 0649
using Abilities;
using UnityEngine;

namespace Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform bulletSpawnPoint;
        
        [SerializeField] private float shootCooldown = 1f;
        private float shootCooldownCounter;

        private void Update()
        {
            if (shootCooldownCounter > 0f)
            {
                shootCooldownCounter -= Time.deltaTime;
            }
        }

        public void Shoot()
        {
            if (!AbilityManager.instance.CanShoot || shootCooldownCounter > 0f) return;

            shootCooldownCounter = shootCooldown;
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }
}
