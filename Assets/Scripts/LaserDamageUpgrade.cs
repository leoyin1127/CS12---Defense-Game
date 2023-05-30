using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamageUpgrade : Upgrade
{
    // Add reference to LaserGunController and initialize in constructor

    public LaserDamageUpgrade(/*LaserGunController laserGunController*/) : base("Laser Damage Upgrade", 125f, 10, 0.05f)
    {
        // Initialize LaserGunController reference
    }

    public override bool CanUpgrade()
    {
        return CurrentLevel < MaxLevel;
    }

    public override void ApplyUpgrade()
    {
        CurrentLevel++;
        // Implement the logic to increase the laser gun's damage
    }
}

