using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FloorGenerate : MonoBehaviour
{
    #region --- Method ---

    private void Awake()
    {
        CreatingFloor();
        point.SetActive(true);
    }

    #region -- Creating Floor --
    private void CreatingFloor()
    {
        int tileCount = spriteData.ForestFloor.Count;
        ResizeMap();
        for (int y = mapD.MapH * -1; y < mapD.MapH; y++)
        {
            for (int x = mapD.MapW * -1; x < mapD.MapW; x++)
            {
                CreateFloor(x, y, tileCount);
            }
        }

        //RandomTileDetail(tileCount);
    }
    #endregion

    #region -- Create floor --
    private void CreateFloor(int x, int y, int tileCount)
    {
        tileMap.CompressBounds();

        Vector3Int tilePos = new Vector3Int(x, y, 0);
        tileMap.SetTile(tilePos, spriteData.ForestFloor[Random.Range(0, tileCount)]);
    }
    #endregion

    // Temporarily closed
    private void RandomTileDetail(int tileCount)
    {
        for (int i = 0; i < 20; i++)
        {
            int x = Random.Range(0, mapD.MapW * 2);
            int y = Random.Range(0, mapD.MapH * 2);

            Vector3Int tilePos = new Vector3Int(x, y, 0);
            tileMap.SetTile(tilePos, spriteData.ForestFloor[Random.Range(1, tileCount)]);
        }
    }

    #region -- Resize map --
    private void ResizeMap()
    {
        mapD.MapW /= 2;
        mapD.MapH /= 2;
    }
    #endregion

    #endregion

    #region --- Field ---

    [SerializeField] private MapDatas mapD;
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private GameObject point;

    [SerializeField] private MapSpriteData spriteData;

    #endregion
}
