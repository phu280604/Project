using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PointGenerate : MonoBehaviour
{
    #region --- Method ---

    private void Start()
    {
        CreatePoint();
        road.SetActive(true);
    }

    #region -- Create point --
    private void CreatePoint()
    {
        int startPoint = 0;
        int endPoint = 0;

        while (Mathf.Abs(endPoint - startPoint) < 3)
        {
            startPoint = Random.Range((mapD.MapW * -1) + 1, mapD.MapW - 1);
            endPoint = Random.Range((mapD.MapW * -1) + 1, mapD.MapW - 1);
        }

        Vector3Int startPos = new Vector3Int(startPoint, mapD.MapH - 1, 0);
        mapD.StartPoint = startPos;
        tileMap.SetTile(startPos, spriteData.point[1]);

        Vector3Int endPos = new Vector3Int(endPoint, mapD.MapH * -1, 0);
        mapD.EndPoint = endPos;
        tileMap.SetTile(endPos, spriteData.point[0]);
    }
    #endregion

    #endregion

    #region --- Field ---

    [SerializeField] private MapDatas mapD;
    [SerializeField] private MapSpriteData spriteData;

    [SerializeField] private Tilemap tileMap;

    [SerializeField] private GameObject road;

    #endregion
}
