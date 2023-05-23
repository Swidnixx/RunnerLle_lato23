using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public GameObject menuPanel;

    private void Start()
    {
        menuPanel.SetActive(false);
    }

    public void PauseButton()
    {
        Input.ResetInputAxes();

        if(menuPanel.activeSelf)
        {
            menuPanel.SetActive(false);
        }
        else
        {
            menuPanel.SetActive(true);
        }
    }
    public void ContinueButton()
    {

    }
    public void HomeButton()
    {

    }
}
