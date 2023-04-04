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
    public float speedUpgradePercent = 0.05f;
    public float damageUpgradePercent = 0.05f;
    public float fireRateUpgradePercent = 0.05f;
    public float laserDamageUpgradePercent = 0.05f;
    public float laserFireRateUpgradePercent = 0.05f;

    // Prices for upgrades and items
    public float speedUpgradePrice = 50f;
    public float damageUpgradePrice = 75f;
    public float fireRateUpgradePrice = 100f;
    public float addLaserGunPrice = 150f;
    public float laserDamageUpgradePrice = 125f;
    public float laserFireRateUpgradePrice = 150f;

    public float playerMoney = 0;

    public Text moneyText;

    public bool ButtonDown = false;

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
            // Implement the logic to increase the player's moving speed by percentage
            // Update the Ship speed variable in MainChar script.
            MainChar mainChar = FindObjectOfType<MainChar>();
            mainChar.ShipInstance.speed *= (1 + speedUpgradePercent);
            Debug.Log("speed up");
            UpdateMoneyText();
            speedUpgradePrice *= 1.1f;
        }
    }


    void UpgradeDamage()
    {
        if (playerMoney >= damageUpgradePrice)
        {
            playerMoney -= damageUpgradePrice;
            // Implement the logic to increase the player's damage by percentage.
            
            WeaponController weaponController = FindObjectOfType<WeaponController>();
            Debug.Log($"player damge: {weaponController.damage}");
            weaponController.damage *= (1 + damageUpgradePercent);
            
            UpdateMoneyText();
            damageUpgradePrice *= 1.1f;
        }
    }

    void UpgradeFireRate()
    {
        if (playerMoney >= fireRateUpgradePrice)
        {
            playerMoney -= fireRateUpgradePrice;
            UpdateMoneyText();
            // Implement the logic to increase the player's firing speed by percentage.
            // Assuming you have a WeaponController script with a fireRate variable:
            ManualWeapon manualWeapon = FindObjectOfType<ManualWeapon>();
            manualWeapon.cooldown *= (1 - fireRateUpgradePercent);
            fireRateUpgradePrice *= 1.1f;
        }
    }

    void AddLaserGun()
    {

        if (playerMoney >= addLaserGunPrice)
        {
            playerMoney -= addLaserGunPrice;
            UpdateMoneyText();
            ButtonDown = true;
            print("11");
            addLaserGunPrice *= 1.1f;
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
            laserDamageUpgradePrice *= 1.1f;
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
            laserFireRateUpgradePrice *= 1.1f;
        }
    }

}
