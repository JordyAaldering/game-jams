using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI description;
    
	private UpgradeBase upgrade;

	public void SetUpgrade(UpgradeBase upgrade)
	{
		this.upgrade = upgrade;
		icon.sprite = upgrade.Icon;
		description.text = upgrade.Description;
	}

	public void GetUpgrade()
	{
		if (UpgradeManager.AcceptClicks) {
			upgrade.GetUpgrade();
		}
	}
}
