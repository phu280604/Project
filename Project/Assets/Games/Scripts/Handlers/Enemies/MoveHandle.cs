using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveHandle : MonoBehaviour
{
    #region --- Method ---

    private void SetStats()
    {
        stats.MiniVan();
    }

    private void Start()
    {
        mapD.StartPoint = FindCentalPos((int)mapD.StartPoint.x, (int)mapD.StartPoint.y);
        mapD.EndPoint = FindCentalPos((int)mapD.EndPoint.x, (int)mapD.EndPoint.y);
        for (int i = 0; i < mapD.RoadPoint.Count; i++)
        {
            mapD.RoadPoint[i] = FindCentalPos((int)mapD.RoadPoint[i].x, (int)mapD.RoadPoint[i].y);
        }

        gameObject.transform.position = mapD.StartPoint;
        curPos = gameObject.transform.position;

        SetStats();


        axisSpeed = 0.01f;
        roadPointC = 0;
    }

    #region -- Update coming soon --
    private void MoveH()
    {
        Vector3 dic = (mapD.RoadPoint[roadPointC] - curPos);
        float mag = dic.magnitude;
        Vector2 normal = dic.normalized;
        Debug.Log(normal);

        if (mag < 1 && roadPointC < mapD.RoadPoint.Count)
        {
            roadPointC++;
        }

        if (normal.y < 0 && normal.x == 0)
            body.velocity = new Vector2(body.velocity.x, 0.1f * normal.y * 8);
        else if (normal.y < 0 && normal.x != 0) 
        {
            body.velocity = new Vector2(0.1f * normal.x * 8, 0.3f * normal.y * 8);
        }
        else if (normal.y == 0 && normal.x != 0)
            body.velocity = new Vector2(0.1f * normal.x * 8, body.velocity.y);

        // Cập nhật curPos sau khi di chuyển
        curPos = gameObject.transform.position;
    }
    #endregion

    private Vector3 FindCentalPos(int x, int y)
    {
        Vector3 cellPos = tileMap.CellToWorld(new Vector3Int(x, y));
        Vector3 cellSize = tileMap.cellSize;
        Vector3 result = cellPos + (cellSize / 2);

        result.z = -1;

        return result;
    }

    private void MoveHanle()
    {
        Vector2 dir = mapD.RoadPoint[roadPointC] - curPos;
        Vector2 normalize = dir.normalized;
        float magnitude = dir.magnitude;

        FlipEnemy(normalize.x);

        Debug.Log("magnitude: "+magnitude);
        if (magnitude < 0.5)
            roadPointC++;

        transform.Translate(normalize * Time.deltaTime * stats.Speed);

        curPos = gameObject.transform.position;
    }

    private void FlipEnemy(float x)
    {
        if (x < 0) transform.localScale = new Vector3(-1, 1, 1);
        else transform.localScale = new Vector3(1, 1, 1);
    }

    private void Update()
    {
        if (curPos == mapD.EndPoint)
            Destroy(gameObject);

        if (roadPointC < mapD.RoadPoint.Count) MoveHanle();
    }

    #endregion

    #region --- Field ---

    [SerializeField] private Tilemap tileMap;
    [SerializeField] private SetUpStats stats;
    [SerializeField] private MapDatas mapD;
    [SerializeField] private Rigidbody2D body;

    [SerializeField] private Vector3 curPos;
    [SerializeField] private Vector3 tarPos;

    private int roadPointC;

    private float axisSpeed;

    #endregion
}
