using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    public enum TileType
    {
        Ground,
        Path,
        Unusable
    }

    public struct TileInfo
    {
        public TileBase animTile;
        public TileType tileType;
        public bool willBeAttacked;

        public TileInfo(TileBase animTile, TileType tileType, bool willBeAttacked)
        {
            this.animTile = animTile;
            this.tileType = tileType;
            this.willBeAttacked = willBeAttacked;
        }
    }

    public Tilemap tileMap;

    public List<string> tilePathName;
    public List<string> tileUnusableName;

    private Dictionary<string, bool> animTileAlreadySee = new Dictionary<string, bool>();
    private List<Vector3Int> animTilesVector3 = new List<Vector3Int>();

    [HideInInspector]
    public TileInfo[,] mapMatrix;
    private BoundsInt mapBounds;

    private float timer = 1;

    void SetMatrix()
    {
        //tileMap.animationFrameRate = 0;

        // SET THE MATRIX
        mapBounds = tileMap.cellBounds;
        mapMatrix = new TileInfo[mapBounds.size.x, mapBounds.size.y];
        TileBase[] allTiles = tileMap.GetTilesBlock(mapBounds);


        // Recupere les tiles et creer la matrice
        for (int x = 0; x < mapBounds.size.x; x++)
        {
            for (int y = 0; y < mapBounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * mapBounds.size.x];
                if (tile != null)
                {
                    AnimatedTile animTile = tileMap.GetTile<AnimatedTile>(new Vector3Int(x, y, 0));
                    TileType tileType;
                    if (tilePathName.Contains(tile.name))
                    {
                        tileType = TileType.Path;
                    }
                    else if (tileUnusableName.Contains(tile.name))
                    {
                        tileType = TileType.Unusable;
                    }
                    else
                    {
                        tileType = TileType.Ground;
                    }
                    mapMatrix[x, y] = new TileInfo(animTile, tileType, true);
                    if (animTile != null)
                    {
                        if (!(animTileAlreadySee.ContainsKey(animTile.name)))
                        {
                            animTilesVector3.Add(new Vector3Int(x, y, 0));
                            animTileAlreadySee.Add(animTile.name, true);
                        }
                        animTile.m_SpriteIndex = 0;
                    }
                }
                else
                {
                    mapMatrix[x, y] = new TileInfo(null, TileType.Unusable, true);
                }
            }
        }
    }

    void Awake()
    {
        SetMatrix();   
    }

    public void updateTiles()
    {
        foreach(Vector3Int animTileVector3 in animTilesVector3)
        {
            ((AnimatedTile)mapMatrix[animTileVector3.x, animTileVector3.y].animTile).m_SpriteIndex += 1;
            if (((AnimatedTile)mapMatrix[animTileVector3.x, animTileVector3.y].animTile).m_SpriteIndex >= ((AnimatedTile)mapMatrix[animTileVector3.x, animTileVector3.y].animTile).m_AnimatedSprites.Length)
            {
                ((AnimatedTile)mapMatrix[animTileVector3.x, animTileVector3.y].animTile).m_SpriteIndex = 0;
            }
        }
        tileMap.RefreshAllTiles();
    }

    // void Update()
    // {
    //     if (timer < Time.time)
    //     {
    //         updateTiles();
    //         timer = Time.time + 1;
    //     }
    // }
}
