using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpecialTurretButton : TurretMenuButton
{

    public GameObject thing;
    public void BuildSpecialTurret()
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
                Instantiate(thing, new Vector2((int)Mathf.Floor(turretManager.desiredPosition.x + 1), (int)Mathf.Floor(turretManager.desiredPosition.y)), Quaternion.identity);
                direction = Vector2.down;
            }
            turretManager.BuildTurret(direction, TurretType.SPECIAL);
        }
    }
}
