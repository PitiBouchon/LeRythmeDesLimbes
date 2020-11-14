using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    [SerializeField] private int attackRate;
    [SerializeField] private float attackDamage;
    [Space]
    [SerializeField] private int buildCost;
    [SerializeField] private int rankOneCost;
    [SerializeField] private int rankTwoCost;

    private int rank = 0;
}
