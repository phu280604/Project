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
        atk = 15;
        atkRange = 1;
        atkDelay = 1;
        speed = 0.45f;
        costDrop = 1;
    }
    #endregion

    #region -- Minion Guard --
    public void MiniGuard()
    {
        hp = 100;
        def = 15;
        atk = 25;
        atkRange = 1;
        atkDelay = 2;
        speed = 0.35f;
        costDrop = 2;
    }
    #endregion

    #region -- Minion Sniper --
    public void MiniSniper()
    {
        hp = 100;
        def = 15;
        atk = 25;
        atkRange = 2;
        atkDelay = 1.5f;
        speed = 0.35f;
        costDrop = 2;
    }

    #endregion

    #region -- Elite Guard --
    public void EliGuard()
    {
        hp = 150;
        def = 25;
        atk = 25;
        atkRange = 1;
        atkDelay = 2.5f;
        speed = 0.3f;
        costDrop = 3;
    }
    #endregion

    #region -- Elite Sniper --
    public void EliSniper()
    {
        hp = 130;
        def = 20;
        atk = 30;
        atkRange = 1;
        atkDelay = 2f;
        speed = 0.25f;
        costDrop = 3;
    }
    #endregion

    #region -- Boss Guard --
    public void BossGuard()
    {
        hp = 250;
        def = 40;
        atk = 60;
        atkRange = 1;
        atkDelay = 4f;
        speed = 0.15f;
        costDrop = 5;
    }
    #endregion

    #endregion
}
