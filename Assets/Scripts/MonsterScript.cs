using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterScript : MonoBehaviour
{
    public Sprite cote1;
    public Sprite cote2;
    private bool cote1Test;
    public Sprite dos;
    public Sprite face;

    [HideInInspector] public List<Vector2> path;
    public int maxHealth = 1;
    private int health;
    public bool friendly = false;
    [HideInInspector] public MonsterManager monsterManager;
    private int actualIndex = 0;

    public RectTransform healthUI;

    private bool droite = true;
    private bool gauche;

    void Start()
    {
        monsterManager = transform.parent.GetComponent<MonsterManager>(); // A CHANGER SI ON CHANGE L'IMPLEMENTATION
        health = maxHealth;
    }
    public void updatePosition()
    {
        actualIndex += 1;
        if (actualIndex >= path.Count)
        {
            if (friendly)
            {
                monsterManager.addFriendlySouls();
            }
            else
            {
                monsterManager.loseLife();
            }
            Destroy(gameObject);
        }
        else
        {
            transform.position = path[actualIndex] + Vector2.one * 0.5f;
            if (path[actualIndex].x < path[actualIndex-1].x)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (path[actualIndex].x > path[actualIndex - 1].x)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            if (path[actualIndex].y < path[actualIndex - 1].y)
            {
                GetComponent<SpriteRenderer>().sprite = face;
            }
            else if (path[actualIndex].y > path[actualIndex - 1].y)
            {
                GetComponent<SpriteRenderer>().sprite = dos;
            }
            else
            {
                if (cote1Test)
                {
                    GetComponent<SpriteRenderer>().sprite = cote1;
                    cote1Test = false;
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = cote2;
                    cote1Test = true;
                }
            }
        }
    }

    void die()
    {
        if(friendly)
        {
            Debug.Log("Die friendly");
        }
            else
        {
            Debug.Log("Die enemy");
            monsterManager.addEnemySouls();
        }

        Destroy(gameObject);
    }

    public void getHit()
    {
        health -= 1;
        if (health <= 0)
        {
            die();
        }
        if (healthUI != null)
        {
            float size = (float)health / (float)maxHealth * 100f;
            healthUI.sizeDelta = new Vector2(size, healthUI.sizeDelta.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            getHit();
        }
    }
}
