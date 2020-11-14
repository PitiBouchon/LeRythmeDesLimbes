using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Turret : MonoBehaviour
{
    [Header("Position parameters")]
    [SerializeField] private Vector2 position;
    [SerializeField] private Vector2 orientation = Vector2.right;

    [Space][Header("Attack parameters")]
    [SerializeField] private int attackRate = 2;
    [SerializeField] private int attackDamage = 1;

    [Space][Header("Souls costs")]
    public int buildCost = 10;
    public int upgradeCost = 5;
    public int sellPrice = 3;

    [Space][Header("UI")]
    [SerializeField] private Canvas turretMenu;
    [SerializeField] private CameraManager cameraManager;

    [Space][Header("Sprites")]
    [SerializeField] private Sprite standardSprite;
    [SerializeField] private Sprite hoverSprite;



    [SerializeField] private int rank = 0;
    [SerializeField] private bool isOn = true;
    
    private MonsterManager monsterManager;
    private SpriteRenderer spriteRenderer;
    private UpgradeButton upgradeButton;
    private SellButton sellButton;
    private Text upgradeCostText;
    private Text sellPriceText;

    private bool isMenuOn = false;

    private void Start()
    {
        monsterManager = FindObjectOfType<MonsterManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cameraManager = FindObjectOfType<CameraManager>();
        spriteRenderer.sprite = standardSprite;
        upgradeButton = turretMenu.transform.Find("UpgradeButton").GetComponent<UpgradeButton>();
        upgradeCostText = upgradeButton.transform.Find("UpgradeCost").GetComponent<Text>();
        sellButton = turretMenu.transform.Find("SellButton").GetComponent<SellButton>();
        sellPriceText = sellButton.transform.Find("SellPrice").GetComponent<Text>();
        UpdateButtons();
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0) && isMenuOn)
        {
            if (!(upgradeButton.isHovered || sellButton.isHovered))
            {
                turretMenu.gameObject.SetActive(false);
                isMenuOn = false;
                cameraManager.shouldMove = true;
            }
        }
    }

    public void TurnOnOff()
    {
        isOn = !isOn;
    }

    public void Upgrade()
    {
        attackDamage++;
        attackRate--;
        monsterManager.setEnemySouls(monsterManager.getEnemySouls() - upgradeCost);
        rank++;
        upgradeCost += 5;
        sellPrice += 3;
        UpdateButtons();
    }

    public void Sell()
    {
        monsterManager.setFriendlySouls(monsterManager.getFriendlySouls() + sellPrice);
        Destroy(this.gameObject);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !isMenuOn)
        {
            TurnOnOff();
        }
        if (Input.GetMouseButtonDown(1))
        {
            turretMenu.gameObject.SetActive(true);
            isMenuOn = true;
            cameraManager.shouldMove = false;
        }
    }

    private void OnMouseEnter()
    {
        spriteRenderer.sprite = hoverSprite;
    }

    private void OnMouseExit()
    {
        spriteRenderer.sprite = standardSprite;
    }

    private void UpdateButtons()
    {
        if (rank == 2)
        {
            upgradeCostText.text = "-";
        }
        else
        {
            upgradeCostText.text = upgradeCost.ToString();
        }
        sellPriceText.text = sellPrice.ToString();
    }
}
