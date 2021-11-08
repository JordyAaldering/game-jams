using UnityEngine;

public abstract class UpgradeBase : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField, TextArea] private string description;

    public Sprite Icon => icon;
    public string Description => description;

    public void GetUpgrade()
	{
        ApplyUpgrade();
        FindObjectOfType<UpgradeManager>().CloseUpgradePanel();
	}

    protected abstract void ApplyUpgrade();
}
