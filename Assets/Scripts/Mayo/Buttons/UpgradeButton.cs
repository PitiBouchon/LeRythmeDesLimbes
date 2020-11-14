using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : TurretMenuButton
{

    public void UpgradeTurret()
    {
        if (correspondingTurret.upgradeCost <= monsterManager.getEnemySouls())
        {
            correspondingTurret.Upgrade();
        }
    }


}
