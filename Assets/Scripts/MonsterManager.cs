using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
    [Serializable]
    public struct Pattern
    {
        public MonsterType[] pattern;
    }

    [Serializable]
    public enum MonsterType
    {
        Friendly,
        Squishy,
        Tank
    }

    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        private Dictionary<TKey, TValue> _Dictionary;

        [SerializeField]
        private List<TKey> _keys = new List<TKey>();

        [SerializeField]
        private List<TValue> _values = new List<TValue>();

        public void OnBeforeSerialize()
        {
            /*_keys.Clear();
            _values.Clear();*/

            foreach (KeyValuePair<TKey, TValue> pair in this)
            {
                _keys.Add(pair.Key);
                _values.Add(pair.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            _Dictionary = new Dictionary<TKey, TValue>();

            for (int i = 0; i != Math.Min(_keys.Count, _values.Count); i++)
                _Dictionary.Add(_keys[i], _values[i]);
        }
    }
    [Serializable]
    public class MonstersDict : SerializableDictionary<MonsterType, GameObject> { }


    // MONTSERS
    public MonstersDict monstersDic;

    // PATTERNS
    [SerializeField]
    public Pattern[] patterns;
    private Queue<MonsterType> monsterQueue;

    // TILES
    public Tilemap tileMap;
    public string tilePathName = "tilesetTest_0";
    private List<Vector2> path1;

    private Vector2 sizeTileMap;
    private string[,] mapMatrix;

    // SOULS and UI
    public Text enemySoulsText;
    public Text friendlySoulsText;
    private int enemySouls = 0;
    private int friendlySouls = 0;

    void Start()
    {
        path1 = tileMap.gameObject.GetComponent<TilemapPath>().path1;

        // SET THE FIRST PATTERN
        addPatternToQueue(patterns[UnityEngine.Random.Range(0, patterns.Length)]);

        // SET THE MATRIX
        BoundsInt bounds = tileMap.cellBounds;
        mapMatrix = new string[bounds.size.x, bounds.size.y];
        TileBase[] allTiles = tileMap.GetTilesBlock(bounds);


        // Recupere les tiles et creer la matrice
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (!(tile is null))
                {
                    mapMatrix[x, y] = (tilePathName == tile.name) ? "path" : "ground";
                }
                else
                {
                    mapMatrix[x, y] = "unknown";
                }
            }
        }

        sizeTileMap = new Vector2(mapMatrix.GetLength(0), mapMatrix.GetLength(1));

        // TEST
        // TileBase tile2 = allTiles[0 + 10 * bounds.size.x];
        //AnimatedTile tile3 = tileMap.GetTile<AnimatedTile>(new Vector3Int(0,10,0));
    }

    void addPatternToQueue(Pattern pattern)
    {
        foreach (MonsterType monsterType in pattern.pattern)
        {
            monsterQueue.Enqueue(monsterType);
        }
    }

    public void addMonster()
    {
        MonsterType monsterType = monsterQueue.Dequeue();
        GameObject monsterToSpawn = monstersDic[monsterType];
        GameObject monsterSpawned = Instantiate(monsterToSpawn, path1[0] + Vector2.one * 0.5f, Quaternion.identity, transform);
        monsterSpawned.GetComponent<MonsterScript>().path = path1;
        if (monsterQueue.Count <= 0)
        {
            addPatternToQueue(patterns[UnityEngine.Random.Range(0, patterns.Length)]);
        }
        Debug.Log("Add a monster");
    }

    public void updateMonsters()
    {
        MonsterScript[] monstersScripts = gameObject.GetComponentsInChildren<MonsterScript>();
        foreach (MonsterScript monsterScript in monstersScripts)
        {
            monsterScript.updatePosition();
        }
    }

    void updateSoulsText(Text text, int number)
    {
        text.text = number.ToString();
    }

    public void addFriendlySouls()
    {
        friendlySouls += 1;
        updateSoulsText(friendlySoulsText, friendlySouls);
    }

    public int getFriendlySouls()
    {
        return friendlySouls;
    }

    public void setFriendlySouls(int friendlySoulsToSet)
    {
        friendlySouls = friendlySoulsToSet;
        updateSoulsText(friendlySoulsText, friendlySouls);
    }


    public void addEnemySouls()
    {
        enemySouls += 1;
        updateSoulsText(enemySoulsText, enemySouls);
    }

    public int getEnemySouls()
    {
        return enemySouls;
    }

    public void setEnemySouls(int enemySoulsToSet)
    {
        enemySouls = enemySoulsToSet;
        updateSoulsText(enemySoulsText, enemySouls);
    }
}
