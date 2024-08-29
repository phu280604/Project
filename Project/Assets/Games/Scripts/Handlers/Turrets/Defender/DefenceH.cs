using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceH : MonoBehaviour
{
    #region --- Method ---

    private void Awake()
    {
        stats.StatsDefender();
    }

    #endregion

    #region --- Field ---

    [SerializeField] private StatsTurrets stats;

    #endregion
}
