using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoreManager : MonoBehaviour
{
    public GameObject storePanel;
    public GameObject topGun;
    public GameObject bottomGun;
    public Button speedUpgradeButton;
    public Button damageUpgradeButton;
    public Button fireRateUpgradeButton;
    public Button addLaserGunButton;
    public Button laserDamageUpgradeButton;
    public Button laserFireRateUpgradeButton;
    public Button addExtraGun1Button;
    public Button addExtraGun2Button;

    private int Upgrade_max = 10;
    private int current_speed_level = 0;
    private int current_damage_level = 0;
    private int current_fireRate_level = 0;
    private int current_laserDamage_level = 0; 
    private int current_laserFireRate_level = 0;

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
    public float addExtraGun1Price = 500f;
    public float addExtraGun2Price = 500f;


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
        addExtraGun1Button.onClick.AddListener(() => AddExtraGun1());
        addExtraGun2Button.onClick.AddListener(() => AddExtraGun2());

        EnemyValues.OnEnemyKilled += IncreasePlayerMoney;
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
        if (playerMoney >= speedUpgradePrice && current_speed_level < Upgrade_max)
        {
            current_speed_level++;
            playerMoney -= speedUpgradePrice;
            // Implement the logic to increase the player's moving speed by percentage
            // Update the Ship speed variable in MainChar script.
            MainChar mainChar = FindObjectOfType<MainChar>();
            mainChar.ShipInstance.Speed *= (1 + speedUpgradePercent);
            Debug.Log("speed up");
            UpdateMoneyText();
        }
    }


    void UpgradeDamage()
    {
        if (playerMoney >= damageUpgradePrice && current_damage_level < Upgrade_max)
        {
            current_damage_level++;
            playerMoney -= damageUpgradePrice;
            // Implement the logic to increase the player's damage by percentage.
            
            WeaponController weaponController = FindObjectOfType<WeaponController>();
            Debug.Log($"player damge: {weaponController.damage}");
            weaponController.damage *= (1 + damageUpgradePercent);
            
            UpdateMoneyText();
        }
    }

    void UpgradeFireRate()
    {
        if (playerMoney >= fireRateUpgradePrice && current_fireRate_level < Upgrade_max)
        {
            current_fireRate_level++;
            playerMoney -= fireRateUpgradePrice;
            UpdateMoneyText();
            // Implement the logic to increase the player's firing speed by percentage.
            // Assuming you have a WeaponController script with a fireRate variable:
            ManualWeapon manualWeapon = FindObjectOfType<ManualWeapon>();
            manualWeapon.cooldown *= (1 - fireRateUpgradePercent);
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
            // Implement the logic to add a laser gun into the scene.
        }
    }

    void UpgradeLaserDamage()
    {
        if (playerMoney >= laserDamageUpgradePrice && current_laserDamage_level < Upgrade_max)
        {
            current_laserDamage_level++;
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
        if (playerMoney >= laserFireRateUpgradePrice && current_laserFireRate_level < Upgrade_max)
        {
            current_laserFireRate_level++;
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

    void AddExtraGun1()
    {
        if (playerMoney >= addExtraGun1Price)
        {
            playerMoney -= addExtraGun1Price;
            UpdateMoneyText();
            addExtraGun1Price *= 1.1f;
            topGun.SetActive(true);
            // Implement the logic to add the first extra gun into the scene.
        }
    }

    void AddExtraGun2()
    {
        if (playerMoney >= addExtraGun2Price)
        {
            playerMoney -= addExtraGun2Price;
            UpdateMoneyText();
            addExtraGun2Price *= 1.1f;

            // Implement the logic to add the second extra gun into the scene.
            bottomGun.SetActive(true);
        }
    }

    void OnDestroy()
    {
        EnemyValues.OnEnemyKilled -= IncreasePlayerMoney;
    }

    void IncreasePlayerMoney(float cashAmount)
    {
        playerMoney += cashAmount;
        UpdateMoneyText();
        Debug.LogWarning($"Player money increased by {cashAmount}");
    }

}
