using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveHandle : MonoBehaviour
{
    #region --- Method ---


    #region -- Set stats
    private void SetStats()
    {
        switch (layer)
        {
            case int n when n == LayerMask.GetMask("MiniVan"):
                stats.MiniVan();
                break;

            case int n when n == LayerMask.GetMask("MiniGuard"):
                stats.MiniGuard();
                break;

            case int n when n == LayerMask.GetMask("MiniSniper"):
                stats.MiniSniper();
                break;

            default:
                Debug.Log("Can't find layer.");
                break;
        }
    }
    #endregion

    #region -- Reset position --
    private void SetSizePos()
    {
        gameObject.transform.position = mapD.StartPoint;
        curPos = gameObject.transform.position;
    }
    #endregion

    #region -- Set default value --
    private void SetDefaultValue()
    {
        roadPointC = 0;
    }
    #endregion

    private void Awake()
    {
        SetSizePos();
        SetDefaultValue();
        SetStats();
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

        /*if (normal.y < 0 && normal.x == 0)
            body.velocity = new Vector2(body.velocity.x, 0.1f * normal.y * 8);
        else if (normal.y < 0 && normal.x != 0) 
        {
            body.velocity = new Vector2(0.1f * normal.x * 8, 0.3f * normal.y * 8);
        }
        else if (normal.y == 0 && normal.x != 0)
            body.velocity = new Vector2(0.1f * normal.x * 8, body.velocity.y);*/

        // Cập nhật curPos sau khi di chuyển
        curPos = gameObject.transform.position;
    }
    #endregion

    #region -- Move handler --
    private void MoveHanle()
    {
        Vector2 dir = mapD.RoadPoint[roadPointC] - curPos;
        Vector2 normalize = dir.normalized;
        float magnitude = dir.magnitude;

        FlipEnemy(normalize.x);

        if (magnitude < 0.25)
            roadPointC++;

        transform.Translate(normalize * Time.fixedDeltaTime * stats.Speed);

        curPos = gameObject.transform.position;
    }
    #endregion

    #region -- Flip enemies --
    private void FlipEnemy(float x)
    {
        if (x < 0) transform.localScale = new Vector3(1, 1, 1);
        else transform.localScale = new Vector3(-1, 1, 1);
    }
    #endregion

    private void Update()
    {
        if (roadPointC < mapD.RoadPoint.Count) MoveHanle();
    }

    #endregion

    #region --- Field ---

    [SerializeField] private EnemiesCommands commands;
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private StatsEnemies stats;
    [SerializeField] private MapDatas mapD;
    [SerializeField] private LayerMask layer;

    [SerializeField] private Vector3 curPos;
    [SerializeField] private Vector3 tarPos;

    private int roadPointC;

    #endregion
}
