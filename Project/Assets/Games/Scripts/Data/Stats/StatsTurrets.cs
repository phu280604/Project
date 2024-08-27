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
        atkDelay = 2;
    }
}
