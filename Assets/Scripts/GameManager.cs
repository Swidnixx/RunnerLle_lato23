using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multipler GMs in the scene");
        Instance = this;
    }

    [Range(0,1)]
    public float worldSpeed = 0.1f;

    public GameObject restartButton;

    private void FixedUpdate()
    {
        worldSpeed += 0.00001f;
    }

    internal void GameOver()
    {
        restartButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameRestart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        Time.timeScale = 1;
    }
}
