using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpecialTurretButton : TurretMenuButton
{
    public void BuildSpecialTurret()
    {
        Debug.Log("bit");
        if (monsterManager.getFriendlySouls() >= turretManager.specialTurret.buildCost)
        {
            turretManager.BuildTurret(Vector2.down, TurretType.SPECIAL);
        }
    }
}
