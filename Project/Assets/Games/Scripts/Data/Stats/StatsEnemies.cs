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

    #region -- Minion Vanguard --
    public void MiniGuard()
    {
        hp = 100;
        def = 15;
        atk = 25;
        atkRange = 1;
        atkDelay = 2;
        speed = 0.2f;
        costDrop = 2;
    }
    #endregion

    #region -- Minion Vanguard --
    public void MiniSniper()
    {
        hp = 100;
        def = 15;
        atk = 25;
        atkRange = 2;
        atkDelay = 1.5f;
        speed = 0.2f;
        costDrop = 2;
    }
    #endregion

    #endregion
}
