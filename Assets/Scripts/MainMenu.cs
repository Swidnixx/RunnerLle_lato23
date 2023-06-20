using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject shopPanel;

    public void MenuShopSwitch( bool toShop )
    {
        SoundManager.Instance.PlayClickUI();

        mainMenuPanel.SetActive(!toShop);
        shopPanel.SetActive(toShop);
    }

    public void PlayButton()
    {
        SoundManager.Instance.PlayClickUI();

        SceneManager.LoadScene(1);
    }
}
