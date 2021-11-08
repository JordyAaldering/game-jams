using System;
using UnityEngine;

public class ScreenShotter : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F12)) {
			TakeScreenshot();
		}
	}

	private void TakeScreenshot()
	{
		string path = $"Itch/{DateTime.Now:yyyy-MM-dd HH-mm-ss}.png";
		ScreenCapture.CaptureScreenshot(path);
		Debug.Log($"Screenshot saved to {path}");
	}
}
