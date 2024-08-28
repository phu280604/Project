using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPoint : MonoBehaviour
{
    void Start()
    {
        Invoke("SetGamePoint", 3f);
    }

    private void SetGamePoint()
    {
        sPoint.transform.position = new Vector3(mapD.StartPoint.x, mapD.StartPoint.y, -1);
        ePoint.transform.position = new Vector3(mapD.EndPoint.x, mapD.EndPoint.y, -1);
    }

    #region --- Field ---

    [SerializeField] private GameObject sPoint;
    [SerializeField] private GameObject ePoint;
    [SerializeField] private MapDatas mapD;

    #endregion
}
