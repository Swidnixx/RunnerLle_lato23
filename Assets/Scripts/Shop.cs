using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public PowerupManager powerupManager;
    public TextMeshProUGUI batteryInfoText;
    public Button batteryButton;
    public TextMeshProUGUI magnetInfoText;
    public Button magnetButton;

    public TextMeshProUGUI coinsText;
    int coins;

    private void Start()
    {
        //for tests only
        //PlayerPrefs.SetInt("Coins", 10000);
        //PlayerPrefs.DeleteKey("Coins");

        coins = PlayerPrefs.GetInt("Coins", 0);
        coinsText.text = coins.ToString();
        DisplayBatteryInfo();
        DisplayMagnetInfo();
    }

    void DisplayMagnetInfo()
    {
        string info = "Lvl " + powerupManager.Magnet.level + "\n";

        if (powerupManager.Magnet.upgraded != null)
        {
            info += "$" + powerupManager.Magnet.upgradeCost + " to upgrade";
        }
        else
        {
            info += "Max level!";
            magnetButton.interactable = false;
        }


        magnetInfoText.text = info;
    }

    public void UpgradeMagnet()
    {
        if (coins >= powerupManager.Magnet.upgradeCost)
        {
            SoundManager.Instance.PlayBuySound();
            coins -= powerupManager.Magnet.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();
            powerupManager.Magnet = powerupManager.Magnet.upgraded as MagnetSO;
            DisplayMagnetInfo();
        }
        else
        {
            SoundManager.Instance.PlayBuyFailed();
            Debug.Log("Not enough money");
        }
    }

    void DisplayBatteryInfo()
    {
        string info = "Lvl " + powerupManager.Immortality.level + "\n";

        if(powerupManager.Immortality.upgraded != null)
        {
            info += "$" + powerupManager.Immortality.upgradeCost + " to upgrade";
        }
        else
        {
            info += "Max level!";
            batteryButton.interactable = false;
        }
  

        batteryInfoText.text = info;
    }

    public void UpgradeButtery()
    {
        if( coins >= powerupManager.Immortality.upgradeCost )
        {
            SoundManager.Instance.PlayBuySound();
            coins -= powerupManager.Immortality.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();
            powerupManager.Immortality = powerupManager.Immortality.upgraded as ImmortalitySO;
            DisplayBatteryInfo();
        }
        else
        {
            SoundManager.Instance.PlayBuyFailed();
            Debug.Log("Not enough money");
        }
    }
}
