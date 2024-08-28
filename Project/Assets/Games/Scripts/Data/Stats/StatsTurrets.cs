using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTurrets : DefaultStats
{
    public void StatsSniper()
    {
        lvl = 1;
        cost = 10;
        hp = 110;
        def = 20;
        atk = 20;
        atkRange = 3;
        atkDelay = 1;
    }

    public void StatsDefender()
    {
        lvl = 1;
        cost = 5;
        hp = 200;
        def = 30;
    }

    public void StatsCaster()
    {
        lvl = 1;
        cost = 20;
        hp = 120;
        def = 20;
        atk = 30;
        atkRange = 4;
        atkDelay = 3;
    }
}
