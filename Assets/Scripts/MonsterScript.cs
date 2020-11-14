using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public List<Vector2> path;
    public int health = 3;
    public int tileSpeed = 1;
    public bool friendly = false;
    private int actualIndex = 0;

    public void updatePosition()
    {
        actualIndex += tileSpeed;
        if (actualIndex >= path.Count)
        {
            Debug.Log("Path ended");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Move forward");
            transform.position = path[actualIndex] + Vector2.one * 0.5f;
        }
    }

    public void getHit()
    {
        health -= 1;
        if (health <= 0)
        {
            if (friendly)
            {
                Debug.Log("Die friendly");
            }
            else
            {
                Debug.Log("Die enemy");
            }
            
            Destroy(gameObject);
        }
    }
}
