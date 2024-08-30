using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTurrets : DefaultStats
{
    #region -- Sniper --
    public void StatsMKI()
    {
        lvl = 1;
        cost = 12;
        costUpgrade = 8;
        hp = 110;
        def = 25;
        atk = 25;
        atkRange = 4;
        atkDelay = 1;
    }
    #endregion

    #region -- Defender --
    public void StatsTank()
    {
        lvl = 1;
        cost = 8;
        costUpgrade = 5;
        hp = 200;
        def = 40;
    }
    #endregion

    #region -- Caster --
    public void StatsMKII()
    {
        lvl = 1;
        cost = 18;
        costUpgrade = 12;
        hp = 120;
        def = 25;
        atk = 30;
        atkRange = 2;
        atkDelay = 3.5f;
    }
    #endregion
}
