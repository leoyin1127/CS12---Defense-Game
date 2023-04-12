using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
    private MainChar mainChar;

    public SpeedUpgrade(MainChar mainChar) : base("Speed Upgrade", 50f, 10, 0.05f)
    {
        this.mainChar = mainChar;
    }

    public override bool CanUpgrade()
    {
        return CurrentLevel < MaxLevel;
    }

    public override void ApplyUpgrade()
    {
        CurrentLevel++;
        mainChar.ShipInstance.Speed *= (1 + UpgradePercent);
    }
}

