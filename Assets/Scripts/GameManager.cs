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

    public PowerupManager powerupManager;
    private void Start()
    {
        DeactivateMagnet();
        powerupManager.Immortality.active = false;
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
        SoundManager.Instance.PlayClickUI();

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

        powerupManager.Magnet.active = true;
        Invoke(nameof(DeactivateMagnet), powerupManager.Magnet.duration);
    }
    void DeactivateMagnet()
    {
        powerupManager.Magnet.active = false;
    }

    public void ActivateImmortality()
    {
        if(powerupManager.Immortality.active)
        {
            CancelInvoke(nameof(DeactivateImmortality));
            worldSpeed -= powerupManager.Immortality.speed;
        }

        powerupManager.Immortality.active = true;
        worldSpeed += powerupManager.Immortality.speed;
        Invoke(nameof(DeactivateImmortality), powerupManager.Immortality.duration);
    }
    void DeactivateImmortality()
    {
        powerupManager.Immortality.active = false;
        worldSpeed -= powerupManager.Immortality.speed;
    }
}
