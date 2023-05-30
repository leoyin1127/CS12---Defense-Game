using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade
{
    public string Name { get; protected set; }
    public float Price { get; protected set; }
    public int CurrentLevel { get; protected set; }
    public int MaxLevel { get; protected set; }
    public float UpgradePercent { get; protected set; }

    public Upgrade(string name, float price, int maxLevel, float upgradePercent)
    {
        Name = name;
        Price = price;
        MaxLevel = maxLevel;
        UpgradePercent = upgradePercent;
        CurrentLevel = 0;
    }

    public abstract bool CanUpgrade();
    public abstract void ApplyUpgrade();
}

