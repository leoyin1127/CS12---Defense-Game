using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoreManager : MonoBehaviour
{
    public GameObject storePanel;
    public Button speedUpgradeButton;
    public Button damageUpgradeButton;
    public Button fireRateUpgradeButton;
    public Button addLaserGunButton;
    public Button laserDamageUpgradeButton;
    public Button laserFireRateUpgradeButton;

    // Percentage increase for upgrades
    public float speedUpgradePercent = 0.1f;
    public float damageUpgradePercent = 0.1f;
    public float fireRateUpgradePercent = 0.1f;
    public float laserDamageUpgradePercent = 0.1f;
    public float laserFireRateUpgradePercent = 0.1f;

    // Prices for upgrades and items
    public int speedUpgradePrice = 50;
    public int damageUpgradePrice = 75;
    public int fireRateUpgradePrice = 100;
    public int addLaserGunPrice = 150;
    public int laserDamageUpgradePrice = 125;
    public int laserFireRateUpgradePrice = 150;

    public int playerMoney = 100000;
    public Text moneyText;

    void Start()
    {
        speedUpgradeButton.onClick.AddListener(() => UpgradeSpeed());
        damageUpgradeButton.onClick.AddListener(() => UpgradeDamage());
        fireRateUpgradeButton.onClick.AddListener(() => UpgradeFireRate());
        addLaserGunButton.onClick.AddListener(() => AddLaserGun());
        laserDamageUpgradeButton.onClick.AddListener(() => UpgradeLaserDamage());
        laserFireRateUpgradeButton.onClick.AddListener(() => UpgradeLaserFireRate());
        UpdateMoneyText();
    }
    private void UpdateMoneyText()
    {
        moneyText.text = $"Money: {playerMoney}";
    }

    public void ShowStore()
    {
        storePanel.SetActive(true);
    }

    public void HideStore()
    {
        storePanel.SetActive(false);
    }

    void UpgradeSpeed()
    {
        if (playerMoney >= speedUpgradePrice)
        {
            playerMoney -= speedUpgradePrice;
            // Implement the logic to increase the player's moving speed by percentage.
            // Update the Ship speed variable in MainChar script.
            MainChar mainChar = FindObjectOfType<MainChar>();
            mainChar.ShipInstance.speed *= (1 + speedUpgradePercent);
            Debug.Log("speed up");
            UpdateMoneyText();
        }
    }


    void UpgradeDamage()
    {
        if (playerMoney >= damageUpgradePrice)
        {
            playerMoney -= damageUpgradePrice;
            UpdateMoneyText();
            // Implement the logic to increase the player's damage by percentage.
            // Assuming you have a PlayerController script with a damage variable:
            // PlayerController playerController = FindObjectOfType<PlayerController>();
            // playerController.damage *= (1 + damageUpgradePercent);
        }
    }

    void UpgradeFireRate()
    {
        if (playerMoney >= fireRateUpgradePrice)
        {
            playerMoney -= fireRateUpgradePrice;
            UpdateMoneyText();
            // Implement the logic to increase the player's firing speed by percentage.
            // Assuming you have a PlayerController script with a fireRate variable:
            // PlayerController playerController = FindObjectOfType<PlayerController>();
            // playerController.fireRate *= (1 + fireRateUpgradePercent);
        }
    }

    void AddLaserGun()
    {
        if (playerMoney >= addLaserGunPrice)
        {
            playerMoney -= addLaserGunPrice;
            UpdateMoneyText();
            // Implement the logic to add a laser gun into the scene.
        }
    }

    void UpgradeLaserDamage()
    {
        if (playerMoney >= laserDamageUpgradePrice)
        {
            playerMoney -= laserDamageUpgradePrice;
            UpdateMoneyText();
            // Implement the logic to increase the laser gun's damage.
            // LaserGunController[] laserGunControllers = FindObjectsOfType<LaserGunController>();
            // foreach (LaserGunController laserGunController in laserGunControllers)
            // {
            //     laserGunController.damage *= (1 + laserDamageUpgradePercent);
            // }
        }
    }

    void UpgradeLaserFireRate()
    {
        if (playerMoney >= laserFireRateUpgradePrice)
        {
            playerMoney -= laserFireRateUpgradePrice;
            UpdateMoneyText();
            // Implement the logic to increase the laser gun's firing speed by percentage.
            // Assuming you have a LaserGunController script with a fireRate variable:
            // LaserGunController[] laserGunControllers = FindObjectsOfType<LaserGunController>();
            // foreach (LaserGunController laserGunController in laserGunControllers)
            // {
            //     laserGunController.fireRate *= (1 + laserFireRateUpgradePercent);
            // }
        }
    }

}