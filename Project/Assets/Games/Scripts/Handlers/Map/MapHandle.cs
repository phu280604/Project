using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapHandle : MonoBehaviour
{
    #region --- Method ---

    #region -- Begin method --
    private void Awake()
    {
        mapD = GetComponent<MapDatas>();
        AutoGenerateMap();
    }
    #endregion

    #region -- Auto create map --
    private void AutoGenerateMap()
    {
        ResizeMap();
        for (int y = mapD.MapH * -1; y <= mapD.MapH; y++)
        {
            for (int x = mapD.MapW * -1; x <= mapD.MapW; x++)
            {
                CreateFloor(x, y);
            }
        }

        CreatePoint();
    }
    #endregion

    #region -- Abs --
    private float Abs(float a)
    {
        if (a < 0) return a * -1;
        return a;
    }
    #endregion

    #region -- Resize map --
    private void ResizeMap()
    {
        mapD.MapW /= 2;
        mapD.MapH /= 2;
    }
    #endregion

    #region -- Create floor --
    private void CreateFloor(int x, int y)
    {
        GameObject tile = Instantiate(mapD.MapUnit);

        tile.transform.position = new Vector2(x, y);

        if (y > 0 && Abs(y) == mapD.MapH) mapD.StartTile.Add(tile);

        if (y < 0 && Abs(y) == mapD.MapH) mapD.EndTile.Add(tile);

        mapD.PathTile.Add(tile);
    }
    #endregion

    #region -- Create point --
    private void CreatePoint()
    {

        int eSpawn = Random.Range(0, mapD.MapW * 2);
        int pHouse = Random.Range(0, mapD.MapW * 2);

        int breakPoint = 0;
        while (Abs(pHouse - eSpawn) < 3)
        {
            eSpawn = Random.Range(0, mapD.MapW * 2);
            pHouse = Random.Range(0, mapD.MapW * 2);
            breakPoint++;
        }

        foreach (var item in mapD.PathTile)
        {
            SpriteRenderer sItem = item.GetComponent<SpriteRenderer>();
            sItem.color = Color.green;
        }

        FindRoad(mapD.StartTile[eSpawn].transform.position, mapD.EndTile[pHouse].transform.position);
        SetUpPoint(mapD.StartTile[eSpawn], mapD.EndTile[pHouse]);
    }
    #endregion

    #region -- Set up road --

    private void FindRoad(Vector2 startPos, Vector2 endPos)
    {
        Vector2 curPos = startPos;

        int y = Random.Range(2, 6);
        for (float i = curPos.y; i > curPos.y - y; i--)
        {
            int index = 0;
            
            index = FindObject(curPos.x, i);
            SetUpRoad(index);
            mapD.RoadTile.Add(mapD.PathTile[index]);
        }
        curPos.y -= y;

        if (curPos.x < endPos.x)
        {
            for(float i = curPos.x; i < endPos.x; i++)
            {
                int index = 0;
                index = FindObject(i, curPos.y);
                SetUpRoad(index);
                mapD.RoadTile.Add(mapD.PathTile[index]);
                if (i == curPos.x) mapD.RoadPoint.Add(mapD.PathTile[index]);
            }
        }
        else if (curPos.x > endPos.x)
        {
            for (float i = curPos.x; i > endPos.x; i--)
            {
                int index = 0;
                index = FindObject(i, curPos.y);
                SetUpRoad(index);
                mapD.RoadTile.Add(mapD.PathTile[index]);
                if (i == curPos.x) mapD.RoadPoint.Add(mapD.PathTile[index]);
            }
        }
        curPos.x = endPos.x;

        for (float i = curPos.y; i >= endPos.y; i--)
        {
            int index = 0;
            index = FindObject(curPos.x, i);
            SetUpRoad(index);
            mapD.RoadTile.Add(mapD.PathTile[index]);
            if (i == curPos.y) mapD.RoadPoint.Add(mapD.PathTile[index]);
        }
    }

    private int FindObject(float x, float y)
    {
        int index = 0;
        for (int i = 0; i < mapD.PathTile.Count; i++)
        {
            float ix = mapD.PathTile[i].transform.position.x;
            float iy = mapD.PathTile[i].transform.position.y;

            if ((Vector2)mapD.PathTile[i].transform.position == new Vector2(x, y))
                index = i;
        }
        return index;
    }

    private void SetUpRoad(int index)
    {
        mapD.PathTile[index].name = "RoadTile";
        mapD.PathTile[index].layer = mapD.Layer;
        mapD.PathTile[index].tag = "RoadTile";

        SpriteRenderer sRoad = mapD.PathTile[index].GetComponent<SpriteRenderer>();
        sRoad.color = Color.cyan;

        Debug.Log($"curPos: ({mapD.PathTile[index].transform.position.x}, {mapD.PathTile[index].transform.position.y})");
    }
    #endregion

    #region -- Set up point --
    private void SetUpPoint(GameObject start, GameObject end)
    {
        start.name = "StartPoint";
        start.tag = "RoadTile";
        start.layer = mapD.Layer;
        mapD.StartPoint = start;
        SpriteRenderer sStart = start.GetComponent<SpriteRenderer>();
        sStart.color = Color.red;

        end.name = "EndPoint";
        end.tag = "RoadTile";
        end.layer = mapD.Layer;
        mapD.EndPoint = end;
        SpriteRenderer sEnd = end.GetComponent<SpriteRenderer>();
        sEnd.color = Color.blue;
    }
    #endregion

    #endregion

    #region --- Field ---

    [SerializeField] private MapDatas mapD;

    #endregion
}