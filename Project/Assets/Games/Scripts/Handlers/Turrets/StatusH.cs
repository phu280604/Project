using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StatusH : MonoBehaviour
{
    #region --- Method ---

    private void Start()
    {
        isPlacing = false;
    }

    public bool IsPlacing { get { return isPlacing; } set { isPlacing = value; } }

    #endregion

    #region --- Field ---

    [SerializeField] private bool isPlacing;

    #endregion
}
