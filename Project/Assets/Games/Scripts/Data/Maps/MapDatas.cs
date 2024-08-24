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
        startTile = new List<GameObject>();
        endTile = new List<GameObject>();
        pathTile = new List<GameObject>();
        roadPoint = new List<GameObject>();
    }
    #endregion

    #region -- Get - Set filed --
    public GameObject MapUnit { get { return mapUnit; } private set { mapUnit = value; } }
    public List<GameObject> StartTile { get { return startTile; } set { startTile = value; } }
    public List<GameObject> EndTile { get { return endTile; } set { endTile = value; } }
    public List<GameObject> RoadTile { get { return roadTile; } set { roadTile = value; } }
    public List<GameObject> PathTile { get { return pathTile; } set { pathTile = value; } }
    public GameObject StartPoint { get { return startPoint; } set { startPoint = value; } }
    public GameObject EndPoint { get { return endPoint; } set { endPoint = value; } }
    public List<GameObject> RoadPoint { get { return roadPoint; } set { roadPoint = value; } }
    public LayerMask Layer { get { return layer; } set { layer = value; } }
    public int MapW { get { return mapW; } set { mapW = value; } }
    public int MapH { get { return mapH; } set { mapH = value; } }
    #endregion

    #endregion

    #region --- Field ---

    [Header("Object")]
    [SerializeField] private GameObject mapUnit;

    [Header("Tile")]
    [SerializeField] private List<GameObject> startTile, endTile;
    [SerializeField] private List<GameObject> roadTile;
    [SerializeField] private List<GameObject> pathTile;

    [Header("Point")]
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject endPoint;
    [SerializeField] private List<GameObject> roadPoint;

    [Header("Layer")]
    [SerializeField] private LayerMask layer;

    [Header("Map size")]
    [SerializeField] private int mapH, mapW;

    #endregion
}
