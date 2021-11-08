using UnityEngine;

public class SetSourceVolume : MonoBehaviour
{
    [SerializeField] private float defaultVolume = 0.8f;
    [SerializeField] private string playerPrefName = "sfxVolume";

	private void Awake()
	{
		float volume = PlayerPrefs.GetFloat(playerPrefName, defaultVolume);
		GetComponent<AudioSource>().volume = volume;
	}
}
