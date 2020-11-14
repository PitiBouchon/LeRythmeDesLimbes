using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapPath : MonoBehaviour
{
    public List<Vector2> path1 = new List<Vector2>();

    void Awake()
    {
        if (path1.Count == 0)
        {
            path1.Add(new Vector2(0, 8));
            path1.Add(new Vector2(1, 8));
            path1.Add(new Vector2(2, 8));
            path1.Add(new Vector2(3, 8));
            path1.Add(new Vector2(4, 8));
            path1.Add(new Vector2(5, 8));
            path1.Add(new Vector2(6, 8));
            path1.Add(new Vector2(6, 9));
            path1.Add(new Vector2(6, 10));
            path1.Add(new Vector2(6, 11));
            path1.Add(new Vector2(6, 12));
            path1.Add(new Vector2(7, 12));
            path1.Add(new Vector2(8, 12));
            path1.Add(new Vector2(9, 12));
            path1.Add(new Vector2(10, 12));
            path1.Add(new Vector2(11, 12));
            path1.Add(new Vector2(12, 12));
            path1.Add(new Vector2(12, 11));
            path1.Add(new Vector2(12, 10));
            path1.Add(new Vector2(12, 9));
            path1.Add(new Vector2(12, 8));
            path1.Add(new Vector2(13, 8));
            path1.Add(new Vector2(14, 8));
            path1.Add(new Vector2(15, 8));
            path1.Add(new Vector2(16, 8));
            path1.Add(new Vector2(17, 8));
            path1.Add(new Vector2(18, 8));
            path1.Add(new Vector2(19, 8));
            path1.Add(new Vector2(20, 8));
            path1.Add(new Vector2(21, 8));
            path1.Add(new Vector2(22, 8));
            path1.Add(new Vector2(23, 8));
            path1.Add(new Vector2(23, 7));
            path1.Add(new Vector2(23, 6));
            path1.Add(new Vector2(23, 5));
            path1.Add(new Vector2(23, 4));
            path1.Add(new Vector2(23, 3));
            path1.Add(new Vector2(23, 2));
            path1.Add(new Vector2(22, 2));
            path1.Add(new Vector2(21, 2));
            path1.Add(new Vector2(20, 2));
            path1.Add(new Vector2(19, 2));
            path1.Add(new Vector2(18, 2));
            path1.Add(new Vector2(17, 2));
        }
    }

    void OnDrawGizmosSelected() // Affiche des ronds sur le chemins
    {
        Gizmos.color = Color.blue;
        foreach (Vector2 pos in path1)
        {
            Gizmos.DrawSphere(new Vector3(pos.x + 0.5f, pos.y + 0.5f, 0), 0.45f);
        }
    }
}
