using System;
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

    // MONTSERS
    public GameObject Friendly;
    public GameObject Squishy;
    public GameObject Tank;

    // PATTERNS
    [SerializeField]
    public Pattern[] patterns;
    private Queue<MonsterType> monsterQueue = new Queue<MonsterType>();

    private bool isGenerating;
    private int nextGenCounter = 5;

    public int minWaitTimeGeneration = 6;
    public int maxWaitTimeGeneration = 9;

    // TILES
    public Tilemap tileMap;
    private List<Vector2> path1;

    // SOULS and UI
    public Text enemySoulsText;
    public Text friendlySoulsText;
    public int enemySouls = 0;
    public int friendlySouls = 0;

    public GameManager gameManager;

    void Awake()
    {
        path1 = tileMap.gameObject.GetComponent<TilemapPath>().path1;

        updateSoulsText(friendlySoulsText, friendlySouls);
        updateSoulsText(enemySoulsText, enemySouls);

        // SET THE FIRST PATTERN
        addPatternToQueue(patterns[UnityEngine.Random.Range(0, patterns.Length)]);

        // TEST
        // TileBase tile2 = allTiles[0 + 10 * bounds.size.x];
        //AnimatedTile tile3 = tileMap.GetTile<AnimatedTile>(new Vector3Int(0,10,0));
    }

    public void addPatternToQueue(Pattern pattern)
    {
        foreach (MonsterType monsterType in pattern.pattern)
        {
            monsterQueue.Enqueue(monsterType);
        }
    }

    public void addMonster(Pattern[] currentPatterns)
    {
        if (isGenerating) {
            MonsterType monsterType = monsterQueue.Dequeue();
            GameObject monsterToSpawn = new GameObject();
            switch (monsterType)
            {
                case MonsterType.Friendly:
                    monsterToSpawn = Friendly;
                    break;
                case MonsterType.Squishy:
                    monsterToSpawn = Squishy;
                    break;
                case MonsterType.Tank:
                    monsterToSpawn = Tank;
                    break;
            }
            GameObject monsterSpawned = Instantiate(monsterToSpawn, path1[0] + Vector2.one * 0.5f, Quaternion.identity, transform);
            monsterSpawned.GetComponent<MonsterScript>().path = new List<Vector2>(path1);
            if (monsterQueue.Count <= 0)
            {
                addPatternToQueue(currentPatterns[UnityEngine.Random.Range(0, patterns.Length)]);
                isGenerating = false;
                nextGenCounter = UnityEngine.Random.Range(minWaitTimeGeneration,maxWaitTimeGeneration);
            }
        }

        else
        {
            nextGenCounter-=1;
            if (nextGenCounter <=0)
            {
                isGenerating = true;
            }

        }

    }

    public void updateMonsters(Pattern[] currentPatterns)
    {
        MonsterScript[] monstersScripts = gameObject.GetComponentsInChildren<MonsterScript>();
        foreach (MonsterScript monsterScript in monstersScripts)
        {
            monsterScript.updatePosition();
        }
        addMonster(currentPatterns);
    }

    void updateSoulsText(Text text, int number)
    {
        text.text = number.ToString();
    }

    public void addFriendlySouls()
    {
        friendlySouls += 1;
        gameManager.Progress();
        
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

    public void loseLife()
    {
        gameManager.LoseLife();
    }
}
