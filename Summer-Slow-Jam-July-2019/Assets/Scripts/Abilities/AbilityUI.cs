#pragma warning disable 0649
using TMPro;
using UnityEngine;

namespace Abilities
{
    public class AbilityUI : MonoBehaviour
    {
        [SerializeField] private GameObject abilityUnlockedPanel;
        [SerializeField] private TextMeshProUGUI abilityText;
        [SerializeField] private TextMeshProUGUI controlText;

        public void Enable(string name, string control)
        {
            Time.timeScale = 0f;
            abilityText.text = name.ToUpper();
            controlText.text = control.ToUpper();
            abilityUnlockedPanel.SetActive(true);
        }

        public void Disable()
        {
            abilityUnlockedPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
