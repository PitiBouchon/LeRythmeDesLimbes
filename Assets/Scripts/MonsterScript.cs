using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    [HideInInspector] public List<Vector2> path;
    public int health = 3;
    public int tileSpeed = 1;
    public bool friendly = false;
    [HideInInspector] public MonsterManager monsterManager;
    private int actualIndex = 0;

    void Start()
    {
        monsterManager = transform.parent.GetComponent<MonsterManager>(); // A CHANGER SI ON CHANGE L'IMPLEMENTATION
        Debug.Log(path.Count);
    }
    public void updatePosition()
    {
        actualIndex += tileSpeed;
        if (actualIndex >= path.Count)
        {
            Debug.Log("Path ended");
            die();
        }
        else
        {
            //Debug.Log("Move forward");
            transform.position = path[actualIndex] + Vector2.one * 0.5f;
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
    }
}
