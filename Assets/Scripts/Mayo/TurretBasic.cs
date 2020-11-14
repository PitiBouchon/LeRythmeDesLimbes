using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class TurretBasic : Turret, TurretInterface
{
    [SerializeField] private Sprite normalTile;
    [SerializeField] private Sprite attackedTile;

    private Tile attackTile;
    private BoxCollider2D attackColliderRight;
    private BoxCollider2D attackColliderLeft;
    private BoxCollider2D attackColliderUp;
    private BoxCollider2D attackColliderDown;

    private new void Start()
    {
        base.Start();
        //attackTile = monsterManager.tileMap.GetTile<Tile>(new Vector3Int((position + orientation).x, (position + orientation).y, 0));
        attackColliderRight = transform.Find("AttackRight").GetComponent<BoxCollider2D>();
        attackColliderLeft = transform.Find("AttackLeft").GetComponent<BoxCollider2D>();
        attackColliderUp = transform.Find("AttackUp").GetComponent<BoxCollider2D>();
        attackColliderDown = transform.Find("AttackDown").GetComponent<BoxCollider2D>();
        attackColliderRight.transform.Translate(new Vector3(1, 0));
        attackColliderLeft.transform.Translate(new Vector3(-1, 0));
        attackColliderUp.transform.Translate(new Vector3(0, 1));
        attackColliderDown.transform.Translate(new Vector3(0, -1));
        attackColliderRight.size = monsterManager.tileMap.cellSize * 0.8f;
        attackColliderLeft.size = monsterManager.tileMap.cellSize * 0.8f;
        attackColliderUp.size = monsterManager.tileMap.cellSize * 0.8f;
        attackColliderDown.size = monsterManager.tileMap.cellSize * 0.8f;
        //attackTile.sprite = normalTile;
        attackColliderRight.gameObject.SetActive(false);
    }

    public void Attack()
    {
        attackColliderRight.gameObject.SetActive(true);
        attackColliderLeft.gameObject.SetActive(true);
        attackColliderUp.gameObject.SetActive(true);
        attackColliderDown.gameObject.SetActive(true);
        //attackTile.sprite = attackedTile;
    }

    private void ResetAttack()
    {
        attackColliderRight.gameObject.SetActive(false);
        attackColliderLeft.gameObject.SetActive(false);
        attackColliderUp.gameObject.SetActive(false);
        attackColliderDown.gameObject.SetActive(false);
        //if (attackTile.sprite != normalTile)
        //{
        //    attackTile.sprite = normalTile;
        //}
    }

    public void TempoUpdate()
    {
        if (!permaAttack)
        {
            ResetAttack();
            if (isOn) 
            {
                if (attackLoad == attackRate-1)
                {
                    Attack();
                    attackLoad = 0;
                }
                else
                {
                    attackLoad++;
                }
            }
        }
        else
        {
            Attack();
        }
    }

    private new void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TempoUpdate();
        }
    }
}
