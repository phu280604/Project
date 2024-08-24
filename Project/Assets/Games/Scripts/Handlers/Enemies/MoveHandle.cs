using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MoveHandle : MonoBehaviour
{
    #region --- Method ---

    private void SetStats()
    {
        switch (gameObject.name)
        {
            case "MiniVanguard":
                stats.MiniVan();
                break;
        }
    }

    private void Start()
    {
        gameObject.transform.position = mapD.StartPoint.transform.position;
        curPos = gameObject.transform.position;

        SetStats();
    }

    private void MoveH()
    {
        Vector2 dicPos = tarPos - curPos;
        dicPos /= 2;

        gameObject.transform.position += (Vector3)(dicPos * 8) * Time.deltaTime;
    }

    private void Update()
    {
        if ((Vector3)curPos == mapD.EndPoint.transform.position)
            Destroy(gameObject);

        if (curPos.y <= tarPos.y) curPos = tarPos;

        MoveH();
    }

    private void CheckGround()
    {
        /*if (mapD.RoadPoint.ContainsKey(curPos + Vector2.down))
        {
            tarPos = curPos + Vector2.down;
        }*/
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    #endregion

    #region --- Field ---

    [SerializeField] private SetUpStats stats;
    [SerializeField] private Vector2 curPos;
    [SerializeField] private Vector2 tarPos;
    [SerializeField] private MapDatas mapD;

    #endregion
}
