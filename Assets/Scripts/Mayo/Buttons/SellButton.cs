using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : TurretMenuButton
{
    public void SellTurret()
    {
        correspondingTurret.Sell();
    }
}
