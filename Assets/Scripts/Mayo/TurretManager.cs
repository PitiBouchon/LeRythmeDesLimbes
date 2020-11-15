using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretManager : MonoBehaviour
{
    [Header("Turrets")]
    public TurretBasic basicTurret;
    public TurretSpecial specialTurret;


    [Space][Header("UI")]
    [SerializeField] private Canvas turretBuildingPanel;
    [SerializeField] private BuildBasicTurretButton basicTurretButton;
    private CameraManager cameraManager;
    private bool isMenuOn = false;
    private Vector2 desiredPosition;
    private Camera camera;


    private MonsterManager monsterManager;
    public List<Turret> turrets;

    private void Start()
    {
        monsterManager = FindObjectOfType<MonsterManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        camera = FindObjectOfType<Camera>();
        turrets = new List<Turret>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isMenuOn)
            {
                desiredPosition = camera.ScreenToWorldPoint(Input.mousePosition);
            }
            turretBuildingPanel.gameObject.SetActive(true);
            isMenuOn = true;
            cameraManager.shouldMove = false;
        }

        if (Input.GetMouseButtonDown(0) && isMenuOn)
        {
            if (!basicTurretButton.isHovered)
            {
                turretBuildingPanel.gameObject.SetActive(false);
                isMenuOn = false;
                cameraManager.shouldMove = true;
            }
        }
    }

    public void BuildTurret(Vector2 orientation, TurretType type)
    {
        switch (type)
        {
            case TurretType.STANDARD:
                TurretBasic turret = Instantiate(basicTurret, desiredPosition, Quaternion.Euler(orientation), transform);
                turrets.Add(turret);
                monsterManager.setFriendlySouls(monsterManager.getFriendlySouls()-turret.buildCost);
                break;
            case TurretType.AOE:
                break;
            case TurretType.RANGE:
                break;
            default:
                break;
        }

        turretBuildingPanel.gameObject.SetActive(false);
        isMenuOn = false;
        cameraManager.shouldMove = true;
    }

    public void TempoUpdate()
    {
        foreach (TurretBasic t in turrets)
        {
            t.TempoUpdate();
        }
    }
}

public enum TurretType
{
    STANDARD,
    SPECIAL,
    AOE,
    RANGE
}
