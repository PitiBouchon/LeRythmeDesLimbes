using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    [SerializeField] private Vector2 position;
    [SerializeField] private Vector2 orientation;
    [Space]
    [SerializeField] private int attackRate;
    [SerializeField] private float attackDamage;
    [Space]
    [SerializeField] private int buildCost;
    [SerializeField] private int rankOneCost;
    [SerializeField] private int rankTwoCost;

    private int rank = 0;
    private bool isOn = true;

    public void TurnOnOff()
    {
        isOn = !isOn;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TurnOnOff();
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
