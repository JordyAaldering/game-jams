using UnityEngine;

namespace Abilities
{
    public class AbilityManager : MonoBehaviour
    {
        public static AbilityManager instance { get; private set; }

        public AbilityUI abilityUI;
        
        private bool _canJump;
        public bool CanJump
        {
            get => _canJump;
            set
            {
                if (_canJump == value) return;
                
                _canJump = value;
                PlayerPrefs.SetInt("CanJump", value ? 1 : 0);
            }
        }
        
        private bool _canDoubleJump;
        public bool CanDoubleJump
        {
            get => _canDoubleJump;
            set
            {
                if (_canDoubleJump == value) return;
                
                _canDoubleJump = value;
                PlayerPrefs.SetInt("CanDoubleJump", value ? 1 : 0);
            }
        }

        private bool _canSlide;
        public bool CanSlide
        {
            get => _canSlide;
            set
            {
                if (_canSlide == value) return;
                
                _canSlide = value;
                PlayerPrefs.SetInt("CanSlide", value ? 1 : 0);
            }
        }

        private bool _canShoot;
        public bool CanShoot
        {
            get => _canShoot;
            set
            {
                if (_canShoot == value) return;
                
                _canShoot = value;
                PlayerPrefs.SetInt("CanShoot", value ? 1 : 0);
            }
        }
        
        private void Awake()
        {
            if (!instance)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            _canJump = PlayerPrefs.GetInt("CanJump") == 1;
            _canDoubleJump = PlayerPrefs.GetInt("CanDoubleJump") == 1;
            _canSlide = PlayerPrefs.GetInt("CanSlide") == 1;
            _canShoot = PlayerPrefs.GetInt("CanShoot") == 1;
        }
    }
}
