using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multipler GMs in the scene");
        Instance = this;
    }

    //GameSettings
    [Range(0,1)]
    public float worldSpeed = 0.1f;

    public GameObject restartButton;

    public MagnetSO magnet;
    public ImmortalitySO immortality;
    private void Start()
    {
        DeactivateMagnet();
        immortality.active = false;
    }

    private void FixedUpdate()
    {
        worldSpeed += 0.00001f;
    }

    //GAME FLOW
    public void GameOver()
    {
        restartButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameRestart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }

    //POWERUPS
    public void ActivateMagnet()
    {
        CancelInvoke(nameof(DeactivateMagnet));

        magnet.active = true;
        Invoke(nameof(DeactivateMagnet), magnet.duration);
    }
    void DeactivateMagnet()
    {
        magnet.active = false;
    }

    public void ActivateImmortality()
    {
        if(immortality.active)
        {
            CancelInvoke(nameof(DeactivateImmortality));
            worldSpeed -= immortality.speed;
        }

        immortality.active = true;
        worldSpeed += immortality.speed;
        Invoke(nameof(DeactivateImmortality), immortality.duration);
    }
    void DeactivateImmortality()
    {
        immortality.active = false;
        worldSpeed -= immortality.speed;
    }
}
