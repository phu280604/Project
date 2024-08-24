using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapSpriteData : MonoBehaviour
{
    #region --- Method ---

    public List<TileBase> ForestFloor { get { return forestFloor; } set { forestFloor = value; } }
    public List<TileBase> WinterFloor { get { return winterFloor; } set { winterFloor = value; } }
    public List<TileBase> DessertFloor { get { return dessertFloor; } set { dessertFloor = value; } }
    public List<TileBase> point { get { return Point; } set { Point = value; } }
    public List<TileBase> Road { get { return road; } set { road = value; } }

    #endregion

    #region --- Field ---

    [SerializeField] private List<TileBase> forestFloor;
    [SerializeField] private List<TileBase> winterFloor;
    [SerializeField] private List<TileBase> dessertFloor;

    [SerializeField] private List<TileBase> Point;

    [SerializeField] private List<TileBase> road;

    #endregion
}
