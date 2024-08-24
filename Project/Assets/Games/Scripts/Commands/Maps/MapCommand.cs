using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCommand : MonoBehaviour
{
    #region --- Method ---

    #region -- Begin method --
    private void Awake()
    {
        mapH = gameObject.GetComponent<MapHandle>();
    }
    #endregion

    #endregion

    #region --- Filed ---

    [SerializeField] private MapHandle mapH;

    #endregion
}
