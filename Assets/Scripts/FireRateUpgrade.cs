using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUpgrade : Upgrade
{
    private ManualWeapon manualWeapon;

    public FireRateUpgrade(ManualWeapon manualWeapon) : base("Fire Rate Upgrade", 100f, 10, 0.05f)
    {
        this.manualWeapon = manualWeapon;
    }

    public override bool CanUpgrade()
    {
        return CurrentLevel < MaxLevel;
    }

    public override void ApplyUpgrade()
    {
        CurrentLevel++;
        manualWeapon.cooldown *= (1 - UpgradePercent);
    }
}

