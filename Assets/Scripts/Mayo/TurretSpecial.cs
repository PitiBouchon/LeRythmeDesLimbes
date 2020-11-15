using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpecial : Turret, TurretInterface
{
    [Header("Attack colliders")]
    private BoxCollider2D one;
    private BoxCollider2D two;
    private BoxCollider2D three;
    private int index = 0;

    [SerializeField] private Sprite rankTwoAttackSprite;


    private new void Start()
    {
        base.Start();
        one = transform.Find("AttackOne").GetComponent<BoxCollider2D>();
        two = transform.Find("AttackTwo").GetComponent<BoxCollider2D>();
        three = transform.Find("AttackThree").GetComponent<BoxCollider2D>();
        one.size = monsterManager.tileMap.cellSize * 0.8f;
        two.size = monsterManager.tileMap.cellSize * 0.8f;
        three.size = monsterManager.tileMap.cellSize * 0.8f;
        one.transform.Translate(new Vector2(-1, 1));
        two.transform.Translate(new Vector2(0, 1));
        three.transform.Translate(new Vector2(1, 1));
    }

    public void Attack()
    {
        ResetAttack();
        if (isOn)
        {
            if (rank == 2)
            {
                one.gameObject.SetActive(true);
                two.gameObject.SetActive(true);
                three.gameObject.SetActive(true);
            }
            switch (index)
            {
                case 0:
                    one.gameObject.SetActive(rank == 1 ? true : false);
                    break;
                case 1:
                    two.gameObject.SetActive(rank == 1 ? true : false);
                    break;
                case 2:
                    three.gameObject.SetActive(rank == 1 ? true : false);
                    break;
                default:
                    index = 0;
                    break;
            }
            index = (index + 1) % 3;
        }

    }

    private void ResetAttack()
    {
        one.gameObject.SetActive(false);
        two.gameObject.SetActive(false);
        three.gameObject.SetActive(false);
    }

    public new void Upgrade()
    {
        base.Upgrade();
        one.GetComponent<SpriteRenderer>().sprite = rankTwoAttackSprite;
        two.GetComponent<SpriteRenderer>().sprite = rankTwoAttackSprite;
        three.GetComponent<SpriteRenderer>().sprite = rankTwoAttackSprite;
    }

    public void TempoUpdate()
    {
        Attack();
    }
}
