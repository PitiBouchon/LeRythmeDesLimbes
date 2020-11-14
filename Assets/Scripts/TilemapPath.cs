using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapPath : MonoBehaviour
{
    public List<Vector2> path1;

    void OnDrawGizmosSelected() // Affiche des ronds sur le chemins
    {
        Gizmos.color = Color.blue;
        foreach (Vector2 pos in path1)
        {
            Gizmos.DrawSphere(new Vector3(pos.x + 0.5f, pos.y + 0.5f, 0), 0.45f);
        }
    }
}
