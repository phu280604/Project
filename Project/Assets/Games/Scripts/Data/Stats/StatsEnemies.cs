using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsEnemies : DefaultStats
{
    public void MiniVan()
    {
        hp = 75;
        def = 10;
        atk = 10;
        atkRange = 1;
        atkSpeed = 5;
        speed = 2f;
        costDrop = 1;
    }
}
