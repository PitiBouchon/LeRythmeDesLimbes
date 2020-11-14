using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretManager : MonoBehaviour
{
    [Header("Turrets")]
    public TurretBasic basicTurret;


    [Space][Header("UI")]
    [SerializeField] private Canvas turretBuildingPanel;
    [SerializeField] private BuildBasicTurretButton basicTurretButton;
    [SerializeField] private Text desiredPlaceMarker;
    private CameraManager cameraManager;
    private bool isMenuOn = false;
    private Vector2 desiredPosition;
    private Camera camera;


    private MonsterManager monsterManager;
    private List<Turret> turrets;

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
                desiredPlaceMarker.rectTransform.position = (camera.ScreenToWorldPoint(Input.mousePosition));
                desiredPlaceMarker.gameObject.SetActive(true);
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
                desiredPlaceMarker.gameObject.SetActive(false);
            }
        }
    }

    public void BuildTurret(Vector2 orientation, TurretType type)
    {
        switch (type)
        {
            case TurretType.STANDARD:
                Instantiate(basicTurret, desiredPosition, Quaternion.Euler(orientation), transform);
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
        desiredPlaceMarker.gameObject.SetActive(false);
    }
}

public enum TurretType
{
    STANDARD,
    AOE,
    RANGE
}
