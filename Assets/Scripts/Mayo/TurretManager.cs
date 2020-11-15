using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretManager : MonoBehaviour
{
    [Header("Turrets")]
    public TurretBasic basicTurret;
    public TurretSpecial specialTurret;

    [Header("Tile")]
    public TilemapManager tileMapManager;

    [Space][Header("UI")]
    [SerializeField] private Canvas turretBuildingPanel;
    [SerializeField] private BuildBasicTurretButton basicTurretButton;
    [SerializeField] private BuildSpecialTurretButton specialTurretButton;
    private CameraManager cameraManager;
    [SerializeField] private bool isMenuOn = false;
    public Vector2 desiredPosition;
    public TileInfo desiredPositionInfo;
    private Camera camera;


    private MonsterManager monsterManager;
    public List<Turret> turrets;

    private void Start()
    {
        monsterManager = FindObjectOfType<MonsterManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        camera = FindObjectOfType<Camera>();
        tileMapManager = FindObjectOfType<TilemapManager>();
        turrets = new List<Turret>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            desiredPosition = camera.ScreenToWorldPoint(Input.mousePosition);
            TileInfo tileInfo = tileMapManager.mapMatrix[(int)Mathf.Floor(desiredPosition.x), (int)Mathf.Floor(desiredPosition.y)];
            Vector3 mousePos = Input.mousePosition;
            Debug.Log(tileInfo.tileType);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            turretBuildingPanel.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            turretBuildingPanel.gameObject.SetActive(true);
            isMenuOn = true;
            cameraManager.shouldMove = false;
        }

        if (Input.GetMouseButtonDown(0) && isMenuOn)
        {
            if (!(basicTurretButton.isHovered || specialTurretButton.isHovered))
            {
                turretBuildingPanel.gameObject.SetActive(false);
                isMenuOn = false;
                cameraManager.shouldMove = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            turretBuildingPanel.gameObject.SetActive(false);
            isMenuOn = false;
            cameraManager.shouldMove = true;
        }
    }

    public void BuildTurret(Vector2 orientation, TurretType type)
    {
        switch (type)
        {
            case TurretType.BASIC:
                TurretBasic turretB = Instantiate(basicTurret, desiredPosition, Quaternion.Euler(orientation), transform);
                turretB.turretType = TurretType.BASIC;
                turrets.Add(turretB);
                monsterManager.setFriendlySouls(monsterManager.getFriendlySouls()-turretB.buildCost);
                break;
            case TurretType.SPECIAL:
                TurretSpecial turretS = Instantiate(specialTurret, desiredPosition, Quaternion.Euler(orientation), transform);
                turretS.turretType = TurretType.SPECIAL;
                turrets.Add(turretS);
                monsterManager.setFriendlySouls(monsterManager.getFriendlySouls() - turretS.buildCost);
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
        foreach (Turret t in turrets)
        {
            if (t.turretType == TurretType.BASIC)
            {
                ((TurretBasic)t).TempoUpdate();
            }
            else if (t.turretType == TurretType.SPECIAL)
            {
                ((TurretSpecial)t).TempoUpdate();
            }
        }
    }
}

public enum TurretType
{
    BASIC,
    SPECIAL,
}
