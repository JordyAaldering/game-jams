using UnityEngine;

namespace Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        [SerializeField] private float mouseDeadZone = 1f;
        [SerializeField] private float speedModifier = 1f;
        [SerializeField] private float speedClamp = 1f;

        private bool isJumpDown;
        
        private PlayerMovement movement;
        private PlayerCombat combat;
        private Transform player;
        private Camera cam;

        private static bool IsPaused => Time.timeScale < 0.1f;

        private void Start()
        {
            GameObject p = GameObject.FindWithTag("Player");

            movement = p.GetComponent<PlayerMovement>();
            combat = p.GetComponent<PlayerCombat>();
            
            player = p.transform;
            cam = Camera.main;
        }

        private void Update()
        {
            if (IsPaused) return;
            
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
            Vector3 playerPos = cam.WorldToScreenPoint(player.position);
            float diff = mousePos.x - playerPos.x;

            if (Mathf.Abs(diff) > mouseDeadZone)
            {
                movement.Move(Mathf.Clamp(diff / (mouseDeadZone * speedModifier), -speedClamp, speedClamp));
            }
            
            if (Mathf.Abs(Input.GetAxisRaw("Jump")) > float.Epsilon)
            {
                if (!isJumpDown)
                {
                    isJumpDown = true;
                    movement.Jump();
                }
            }
            else
            {
                isJumpDown = false;
            }
            
            if (Mathf.Abs(Input.GetAxisRaw("Slide")) > float.Epsilon)
            {
                movement.Slide();
            }
            
            if (Mathf.Abs(Input.GetAxisRaw("Shoot")) > float.Epsilon)
            {
                combat.Shoot();
            }
        }
    }
}
