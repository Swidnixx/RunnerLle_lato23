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
        mainMenuPanel.SetActive(!toShop);
        shopPanel.SetActive(toShop);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
}
