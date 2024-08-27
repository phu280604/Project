using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

public class RoadGenerate : MonoBehaviour
{
    #region --- Method ---

    void Start()
    {
        GenarateRoad();
        SetSizePos();

        Invoke("StartSpawn", 2f);
    }

    private void SetSizePos()
    {
        mapD.StartPoint = FindCentalPos((int)mapD.StartPoint.x, (int)mapD.StartPoint.y);
        mapD.EndPoint = FindCentalPos((int)mapD.EndPoint.x, (int)mapD.EndPoint.y);
        for (int i = 0; i < mapD.RoadPoint.Count; i++)
        {
            mapD.RoadPoint[i] = FindCentalPos((int)mapD.RoadPoint[i].x, (int)mapD.RoadPoint[i].y);
        }
    }

    #region -- Finding central position --
    private Vector3 FindCentalPos(int x, int y)
    {
        Vector3 cellPos = tileMap.CellToWorld(new Vector3Int(x, y));
        Vector3 cellSize = tileMap.cellSize;
        Vector3 result = cellPos + (cellSize / 2);

        result.z = -1;

        return result;
    }
    #endregion

    #region -- Genarate road --
    private void GenarateRoad()
    {
        Vector3Int curPos = new Vector3Int((int)mapD.StartPoint.x, (int)mapD.StartPoint.y);
        Vector3Int endPos = new Vector3Int((int)mapD.EndPoint.x, (int)mapD.EndPoint.y);

        int roadCount = spriteData.Road.Count;

        int y = Random.Range(2, 6);
        for (int i = curPos.y - 1; i > curPos.y - y; i--)
        {
            tileMap.SetTile(new Vector3Int(curPos.x, i, 0), spriteData.Road[Random.Range(0, roadCount)]); 
        }
        curPos.y -= y;

        if (curPos.x < endPos.x)
        {
            for (int i = curPos.x; i < endPos.x; i++)
            {
                Vector3Int pos = new Vector3Int(i, curPos.y, 0);
                tileMap.SetTile(pos, spriteData.Road[Random.Range(0, roadCount)]);
                
                if (i == curPos.x) mapD.RoadPoint.Add(pos);
            }
        }
        else if (curPos.x > endPos.x)
        {
            for (int i = curPos.x; i > endPos.x; i--)
            {
                Vector3Int pos = new Vector3Int(i, curPos.y, 0);
                tileMap.SetTile(pos, spriteData.Road[Random.Range(0, roadCount)]);

                if (i == curPos.x) mapD.RoadPoint.Add(pos);
            }
        }
        curPos.x = endPos.x;

        for (int i = curPos.y; i > endPos.y; i--)
        {
            Vector3Int pos = new Vector3Int(curPos.x, i, 0);
            tileMap.SetTile(pos, spriteData.Road[Random.Range(0, roadCount)]);

            if (i == curPos.y) mapD.RoadPoint.Add(pos);
        }

        mapD.RoadPoint.Add(new Vector3Int(endPos.x, endPos.y, 0));
    }
    #endregion

    #region -- Start spawn --
    private void StartSpawn()
    {
        enemies.SetActive(true);
        Debug.Log("Spawn");
    }
    #endregion

    #endregion

    #region --- Field ---

    [SerializeField] private MapDatas mapD;
    [SerializeField] private MapSpriteData spriteData;

    [SerializeField] private Tilemap tileMap;
    [SerializeField] private GameObject enemies;

    #endregion
}
