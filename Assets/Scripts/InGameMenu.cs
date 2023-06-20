using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject menuPanel;

    private void Start()
    {
        menuPanel.SetActive(false);
    }

    public void PauseButton()
    {
        SoundManager.Instance.PlayClickUI();

        if(menuPanel.activeSelf)
        {
            menuPanel.SetActive(false);
            GameManager.Instance.Resume();
        }
        else
        {
            menuPanel.SetActive(true);
            GameManager.Instance.Pause();
        }
    }
    public void ContinueButton()
    {
        SoundManager.Instance.PlayClickUI();

        menuPanel.SetActive(false);
        GameManager.Instance.Resume();
    }
    public void HomeButton()
    {
        SoundManager.Instance.PlayClickUI();

        SceneManager.LoadScene(0);
        GameManager.Instance.Resume();
    }
}
