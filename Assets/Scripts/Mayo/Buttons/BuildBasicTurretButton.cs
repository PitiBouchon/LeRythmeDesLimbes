using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBasicTurretButton : TurretMenuButton
{    
    public void BuildBasicTurret()
    {
        if (monsterManager.getFriendlySouls() >= turretManager.basicTurret.buildCost)
        {
            turretManager.BuildTurret(Vector2.right, TurretType.BASIC);
        }
    }
}
