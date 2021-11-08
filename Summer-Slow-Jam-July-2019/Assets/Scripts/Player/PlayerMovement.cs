#pragma warning disable 0649
using Abilities;
using Audio;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed = 3f;
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private float speedIncrease = 0.005f;
        [SerializeField] private float jumpForce = 3f;

        [SerializeField] private float slideCooldown = 1f;
        private float slideCooldownCounter;

        [SerializeField] private Transform groundCheck;

        private bool IsGrounded => Physics.Raycast(groundCheck.position, Vector3.down, 0.05f);
        private bool CanJump => IsGrounded && AbilityManager.instance.CanJump;

        private bool canDoubleJump;
        private bool CanDoubleJump => canDoubleJump && AbilityManager.instance.CanDoubleJump;

        private Rigidbody rb;
        private Animator anim;
        
        private static readonly int slide = Animator.StringToHash("Slide");

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();
        }

        private void FixedUpdate()
        {
            float increase = (speedIncrease * Time.deltaTime);
            
            forwardSpeed += forwardSpeed * increase;
            moveSpeed += moveSpeed * increase;
            rb.velocity = rb.velocity.With(x: forwardSpeed);

            if (slideCooldownCounter > 0f)
            {
                slideCooldownCounter -= Time.deltaTime;
            }
        }

        public void Move(float amount)
        {
            transform.Translate(moveSpeed * Time.deltaTime * new Vector3(amount, 0f, 0f));
        }

        public void Jump()
        {
            if (CanJump)
            {
                AudioManager.instance.PlayEffect(AudioManager.instance.jumpClip);
                
                canDoubleJump = true;
                rb.velocity = rb.velocity.With(y: jumpForce);
            }
            else if (CanDoubleJump)
            {
                AudioManager.instance.PlayEffect(AudioManager.instance.jumpClip);
                
                canDoubleJump = false;
                rb.velocity = rb.velocity.With(y: jumpForce);
            }
        }

        public void Slide()
        {
            if (!AbilityManager.instance.CanSlide || slideCooldownCounter > 0f) return;
            
            AudioManager.instance.PlayEffect(AudioManager.instance.slideClip);
            
            slideCooldownCounter = slideCooldown;
            anim.SetTrigger(slide);
        }
    }
}
