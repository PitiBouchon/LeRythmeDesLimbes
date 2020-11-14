﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MonsterManager : MonoBehaviour
{
    // MONTSERS
    public GameObject[] monsters;

    // TILES
    public Tilemap tileMap;
    public List<Vector2> path1;
    public string tilePath = "tilesetTest_0";

    private Vector2 sizeTileMap;
    private string[,] mapMatrix;

    void OnDrawGizmosSelected() // Affiche des ronds sur le chemins
    {
        Gizmos.color = Color.blue;
        foreach (Vector2 pos in path1)
        {
            Gizmos.DrawSphere(new Vector3(pos.x + 0.5f, pos.y + 0.5f, 0), 0.45f);
        }
    }

    void Start()
    {
        BoundsInt bounds = tileMap.cellBounds;
        mapMatrix = new string[bounds.size.x, bounds.size.y];
        TileBase[] allTiles = tileMap.GetTilesBlock(bounds);

        // Recupere les tiles et creer la matrice
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                mapMatrix[x, y] = (tilePath == tile.name) ? "path" : "ground";
            }
        }

        sizeTileMap = new Vector2(mapMatrix.GetLength(0), mapMatrix.GetLength(1));
    }

    public void addMonster()
    {
        GameObject monsterToSpawn = monsters[Random.Range(0, monsters.Length)];
        GameObject monsterSpawned = Instantiate(monsterToSpawn, path1[0] + Vector2.one*0.5f, Quaternion.identity, transform);
        monsterSpawned.GetComponent<MonsterScript>().path = path1;
        Debug.Log("Add a monster");
    }

    public void updateMonsters()
    {
        MonsterScript[] monstersScripts = gameObject.GetComponentsInChildren<MonsterScript>();
        foreach(MonsterScript monsterScript in monstersScripts)
        {
            monsterScript.updatePosition();
        }
    }
}