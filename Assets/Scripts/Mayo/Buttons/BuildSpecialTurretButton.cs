using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpecialTurretButton : TurretMenuButton
{

    public GameObject thing;
    public void BuildSpecialTurret()
    {
        if (turretManager.desiredPositionInfo.tileType == TileType.Ground)
        {
            if (monsterManager.getFriendlySouls() >= turretManager.specialTurret.buildCost)
            {
                Vector2 direction;
                if (turretManager.tileMapManager.mapMatrix[(int)Mathf.Floor(turretManager.desiredPosition.x), (int)Mathf.Floor(turretManager.desiredPosition.y - 1)].tileType == TileType.Path)
                {
                    direction = Vector2.down;
                }
                else if (turretManager.tileMapManager.mapMatrix[(int)Mathf.Floor(turretManager.desiredPosition.x - 1), (int)Mathf.Floor(turretManager.desiredPosition.y)].tileType == TileType.Path)
                {
                    direction = Vector2.left;
                }
                else if (turretManager.tileMapManager.mapMatrix[(int)Mathf.Floor(turretManager.desiredPosition.x), (int)Mathf.Floor(turretManager.desiredPosition.y + 1)].tileType == TileType.Path)
                {
                    direction = Vector2.up;
                }
                else if (turretManager.tileMapManager.mapMatrix[(int)Mathf.Floor(turretManager.desiredPosition.x + 1), (int)Mathf.Floor(turretManager.desiredPosition.y)].tileType == TileType.Path)
                {
                    direction = Vector2.right;
                }
                else
                {
                    direction = Vector2.down;
                }
                turretManager.BuildTurret(direction, TurretType.SPECIAL);
            }
        }
        }
}
