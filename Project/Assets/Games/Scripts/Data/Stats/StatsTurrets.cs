using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTurrets : DefaultStats
{
    #region -- MK I --
    public void StatsMKI()
    {
        lvl = 1;
        cost = 12;
        costUpgrade = 8;
        maxHP = 110;
        hp = 110;
        def = 25;
        atk = 35;
        atkRange = 3f;
        atkDelay = 1;
    }
    #endregion

    #region -- Tank --
    public void StatsTank()
    {
        lvl = 1;
        cost = 8;
        costUpgrade = 5;
        maxHP = 200;
        hp = 200;
        def = 40;
        atk = 25;
        atkRange = 1.5f;
        atkDelay = 1;
    }
    #endregion

    #region -- MK II --
    public void StatsMKII()
    {
        lvl = 1;
        cost = 18;
        costUpgrade = 12;
        maxHP = 120;
        hp = 120;
        def = 25;
        atk = 45;
        atkRange = 2.5f;
        atkDelay = 3.5f;
    }
    #endregion
}
