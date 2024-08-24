using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MapDatas : MonoBehaviour
{
    #region --- Method ---

    #region -- Begin method --
    private void Awake()
    {
        pathTile = new List<GameObject>();
        roadPoint = new List<Vector3>();
    }
    #endregion

    #region -- Get - Set filed --
    public List<GameObject> RoadTile { get { return roadTile; } set { roadTile = value; } }
    public List<GameObject> PathTile { get { return pathTile; } set { pathTile = value; } }
    public Vector3 StartPoint { get { return startPoint; } set { startPoint = value; } }
    public Vector3 EndPoint { get { return endPoint; } set { endPoint = value; } }
    public List<Vector3> RoadPoint { get { return roadPoint; } set { roadPoint = value; } }
    public LayerMask Layer { get { return layer; } set { layer = value; } }
    public int MapW { get { return mapW; } set { mapW = value; } }
    public int MapH { get { return mapH; } set { mapH = value; } }
    #endregion

    #endregion

    #region --- Field ---

    [Header("Tile")]
    [SerializeField] private List<GameObject> roadTile;
    [SerializeField] private List<GameObject> pathTile;

    [Header("Point")]
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;
    [SerializeField] private List<Vector3> roadPoint;

    [Header("Layer")]
    [SerializeField] private LayerMask layer;

    [Header("Map size")]
    [SerializeField] private int mapH, mapW;

    #endregion
}
