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

    public Text moneyText;

    public float playerMoney = 0;

    private List<Upgrade> upgrades;

    void Start()
    {
        InitializeUpgrades();
        InitializeButtons();

        EnemyValues.OnEnemyKilled += IncreasePlayerMoney;
        UpdateMoneyText();
    }

    private void InitializeUpgrades()
    {
        upgrades = new List<Upgrade>
        {
            new SpeedUpgrade(),
            new DamageUpgrade(),
            new FireRateUpgrade(),
            new LaserDamageUpgrade(),
            new LaserFireRateUpgrade(),
        };
    }

    private void InitializeButtons()
    {
        speedUpgradeButton.onClick.AddListener(() => UpgradeItem("Speed"));
        damageUpgradeButton.onClick.AddListener(() => UpgradeItem("Damage"));
        fireRateUpgradeButton.onClick.AddListener(() => UpgradeItem("FireRate"));
        addLaserGunButton.onClick.AddListener(() => AddLaserGun());
        laserDamageUpgradeButton.onClick.AddListener(() => UpgradeItem("LaserDamage"));
        laserFireRateUpgradeButton.onClick.AddListener(() => UpgradeItem("LaserFireRate"));
        addExtraGun1Button.onClick.AddListener(() => AddExtraGun1());
        addExtraGun2Button.onClick.AddListener(() => AddExtraGun2());
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

    public void UpgradeItem(string upgradeName)
    {
        foreach (Upgrade upgrade in upgrades)
        {
            if (upgrade.Name == upgradeName)
            {
                if (playerMoney >= upgrade.Price && upgrade.CanUpgrade())
                {
                    playerMoney -= upgrade.Price;
                    upgrade.ApplyUpgrade();
                    UpdateMoneyText();
                }
                break;
            }
        }
    }

    void AddLaserGun()
    {
        // Implement the logic to add a laser gun into the scene.
    }

    void AddExtraGun1()
    {
        // Implement the logic to add the first extra gun into the scene.
        topGun.SetActive(true);
    }

    void AddExtraGun2()
    {
        // Implement the logic to add the second extra gun into the scene.
        bottomGun.SetActive(true);
    }

    void OnDestroy()
    {
        EnemyValues.OnEnemyKilled -= IncreasePlayerMoney;
    }

    void IncreasePlayerMoney(float cashAmount)
    {
        playerMoney += cashAmount;
        UpdateMoneyText();
    }
}
