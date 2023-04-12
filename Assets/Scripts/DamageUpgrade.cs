using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade : Upgrade
{
    private WeaponController weaponController;

    public DamageUpgrade(WeaponController weaponController) : base("Damage Upgrade", 75f, 10, 0.05f)
    {
        this.weaponController = weaponController;
    }

    public override bool CanUpgrade()
    {
        return CurrentLevel < MaxLevel;
    }

    public override void ApplyUpgrade()
    {
        CurrentLevel++;
        weaponController.damage *= (1 + UpgradePercent);
    }
}

