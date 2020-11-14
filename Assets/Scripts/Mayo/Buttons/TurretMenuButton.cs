using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretMenuButton : MonoBehaviour
{
    protected Turret correspondingTurret;
    protected MonsterManager monsterManager;
    protected TurretManager turretManager;
    protected Camera camera;
    public bool isHovered = false;

    private void Start()
    {
        monsterManager = FindObjectOfType<MonsterManager>();
        correspondingTurret = transform.parent.GetComponentInParent<Turret>();
        turretManager = FindObjectOfType<TurretManager>();
        camera = FindObjectOfType<Camera>();
    }

    public void SetHoverTrue()
    {
        isHovered = true;
    }

    public void SetHoverFalse()
    {
        isHovered = false;
    }
}
