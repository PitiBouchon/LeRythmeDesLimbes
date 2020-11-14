using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : TurretMenuButton
{
    private void UpgradeTurret()
    {
        correspondingTurret.Upgrade();
    }
}
