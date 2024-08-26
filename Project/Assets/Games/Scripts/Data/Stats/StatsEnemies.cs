using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsEnemies : DefaultStats
{
    #region --- Method ---

    #region -- Minion Vanguard --
    public void MiniVan()
    {
        hp = 75;
        def = 10;
        atk = 10;
        atkRange = 1;
        atkDelay = 3;
        speed = 0.3f;
        costDrop = 1;
    }
    #endregion

    #endregion
}
