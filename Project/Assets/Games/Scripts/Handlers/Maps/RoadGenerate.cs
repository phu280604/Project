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
        Invoke("StartSpawn", 2f);
    }

    #region -- Genarate road --
    private void GenarateRoad()
    {
        Vector3Int curPos = new Vector3Int((int)mapD.StartPoint.x, (int)mapD.StartPoint.y);
        Vector3Int endPos = new Vector3Int((int)mapD.EndPoint.x, (int)mapD.EndPoint.y);

        int roadCount = spriteData.Road.Count;

        int y = Random.Range(2, 6);
        for (int i = curPos.y - 1; i > curPos.y - y; i--)
        { 
            tilemap.SetTile(new Vector3Int(curPos.x, i, 0), spriteData.Road[Random.Range(0, roadCount)]); 
        }
        curPos.y -= y;

        if (curPos.x < endPos.x)
        {
            for (int i = curPos.x; i < endPos.x; i++)
            {
                Vector3Int pos = new Vector3Int(i, curPos.y, 0);
                tilemap.SetTile(pos, spriteData.Road[Random.Range(0, roadCount)]);
                
                if (i == curPos.x) mapD.RoadPoint.Add(pos);
            }
        }
        else if (curPos.x > endPos.x)
        {
            for (int i = curPos.x; i > endPos.x; i--)
            {
                Vector3Int pos = new Vector3Int(i, curPos.y, 0);
                tilemap.SetTile(pos, spriteData.Road[Random.Range(0, roadCount)]);

                if (i == curPos.x) mapD.RoadPoint.Add(pos);
            }
        }
        curPos.x = endPos.x;

        for (int i = curPos.y; i > endPos.y; i--)
        {
            Vector3Int pos = new Vector3Int(curPos.x, i, 0);
            tilemap.SetTile(pos, spriteData.Road[Random.Range(0, roadCount)]);

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

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private GameObject enemies;

    #endregion
}
