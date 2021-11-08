#pragma warning disable 0649
using System;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance { get; private set; }

    [SerializeField] private GameObject gameOverPanel;

    private bool _gameOver;
    public bool gameOver
    {
        get => _gameOver;
        set
        {
            if (value == false) throw new Exception("Can't set game over back to false.");
            
            foreach (GameObject go in player) go.SetActive(false);
            
            _gameOver = true;
            
            Time.timeScale = 0.2f;
            gameOverPanel.SetActive(true);
        }
    }

    private GameObject[] player;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }
}
