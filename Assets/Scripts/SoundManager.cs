using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    AudioSource audioSource;
    public AudioClip clickUI;
    public AudioClip buyUI;
    public AudioClip buyFail;
    public AudioClip pickup;
    public AudioClip dead;
    public AudioClip magnet;
    public AudioClip battery;
    public AudioClip jump;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClickUI()
    {
        audioSource.PlayOneShot(clickUI);
    }
    public void PlayBuySound()
    {
        audioSource.PlayOneShot(buyUI);
    }
    public void PlayBuyFailed()
    {
        audioSource.PlayOneShot(buyFail);
    }
    public void PlayPickup()
    {
        audioSource.PlayOneShot(pickup);
    }

    public void PlayDead()
    {
        audioSource.PlayOneShot(dead);
    }

    public void PlayMagnet()
    {
        audioSource.PlayOneShot(magnet);
    }
    public void PlayBattery()
    {
        audioSource.PlayOneShot(battery);
    }
    public void PlayJump()
    {
        audioSource.PlayOneShot(jump);
    }
}
