using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Turret : MonoBehaviour
{
    [Header("Position parameters")]
    [SerializeField] private Vector2 position;
    [SerializeField] private Vector2 orientation;
    [Space][Header("Attack parameters")]
    [SerializeField] private int attackRate;
    [SerializeField] private float attackDamage;
    [Space][Header("Souls costs")]
    [SerializeField] private int rankZeroCost;
    [SerializeField] private int rankOneCost;
    [SerializeField] private int rankTwoCost;
    [SerializeField] private int rankZeroSellPrice;
    [SerializeField] private int rankOneSellPrice;
    [SerializeField] private int rankTwoSellPrice;
    [Space][Header("UI")]
    [SerializeField] private 


    private int rank = 0;
    private bool isOn = true;
    private MonsterManager monsterManager;

    private void Start()
    {
        monsterManager = new MonsterManager();
    }

    public void TurnOnOff()
    {
        isOn = !isOn;
    }

    public void Upgrade()
    {
        int cost = 0;
        switch (rank)
        {
            case 0:
                cost = rankOneCost;
                break;
            case 1:
                cost = rankTwoCost;
                break;
            default:
                break;
        }
        monsterManager.SetEnemySouls(monsterManager.GetEnemySouls() - cost);
        rank++;
    }

    public void Sell()
    {
        int sellPrice = 0;
        switch (rank)
        {
            case 0:
                sellPrice = rankZeroSellPrice;
                break;
            case 1:
                sellPrice = rankOneSellPrice;
                break;
            case 2:
                sellPrice = rankTwoSellPrice;
                break;
            default:
                break;
        }
        monsterManager.SetFriendlySouls(monsterManager.GetFriendlySouls() + sellPrice);
        Destroy(this.gameObject);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TurnOnOff();
        }
        if (Input.GetMouseButtonDown(1))
        {
            
        }
    }

    private void OnMouseEnter()
    {
        //TODO Changer la sprite à Hover
    }

    private void OnMouseExit()
    {
        //TODO Remettre la sprite normale
    }
}
