using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class TurretBasic : Turret, TurretInterface
{
    [SerializeField] private Sprite normalTile;
    [SerializeField] private Sprite attackedTile;

    private Tile attackTile;
    private BoxCollider2D attackCollider;

    private new void Start()
    {
        base.Start();
        //attackTile = monsterManager.tileMap.GetTile<Tile>(new Vector3Int((position + orientation).x, (position + orientation).y, 0));
        attackCollider = transform.Find("Attack").GetComponent<BoxCollider2D>();
        attackCollider.transform.Translate(new Vector3(orientation.x, orientation.y));
        attackCollider.size = monsterManager.tileMap.cellSize;
        //attackTile.sprite = normalTile;
        attackCollider.gameObject.SetActive(false);
    }

    public void Attack()
    {
        attackCollider.gameObject.SetActive(true);
        //attackTile.sprite = attackedTile;
    }

    private void ResetAttack()
    {
        attackCollider.gameObject.SetActive(false);
        //if (attackTile.sprite != normalTile)
        //{
        //    attackTile.sprite = normalTile;
        //}
    }

    public void TempoUpdate()
    {
        ResetAttack();
        if (attackLoad == attackRate)
        {
            Attack();
            attackLoad = 0;
        }
        else
        {
            attackLoad++;
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
