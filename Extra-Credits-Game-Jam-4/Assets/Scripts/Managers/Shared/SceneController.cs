using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static event Action OnSceneEnd = delegate { };

    public void LoadScene(int buildIndex)
    {
        StartCoroutine(Load(buildIndex));
    }
    
    public void LoadSceneNoWait(int buildIndex)
    {
        StartCoroutine(Load(buildIndex, 0f));
    }

    private static IEnumerator Load(int buildIndex, float waitTime = 1f)
    {
        Time.timeScale = 1f;
        
        AudioController.instance.Select();
        
        OnSceneEnd();
        OnSceneEnd = delegate { };
        
        yield return new WaitForSeconds(waitTime);
        
        SceneManager.LoadScene(buildIndex);
    }

    public void Quit()
    {
        AudioController.instance.Select();
        
        Application.Quit();
    }
}
