using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsEnemies : DefaultStats
{
    #region --- Method ---

    #region -- Mushroom --
    public void Mushroom()
    {
        maxHP = 110;
        hp = 110;
        def = 25;
        atk = 25;
        atkRange = 1;
        atkDelay = 1;
        speed = 0.45f;
        costDrop = 1;
    }
    #endregion

    #region -- Skeleton --
    public void Skeleton()
    {
        maxHP = 150;
        hp = 150;
        def = 30;
        atk = 35;
        atkRange = 1;
        atkDelay = 2;
        speed = 0.35f;
        costDrop = 1;
    }
    #endregion

    #region -- Bat --
    public void Bat()
    {
        maxHP = 125;
        hp = 125;
        def = 25;
        atk = 40;
        atkRange = 2;
        atkDelay = 1.5f;
        speed = 0.35f;
        costDrop = 1;
    }

    #endregion

    #region -- Goblin --
    public void Goblin()
    {
        maxHP = 200;
        hp = 200;
        def = 40;
        atk = 50;
        atkRange = 1;
        atkDelay = 2.5f;
        speed = 0.3f;
        costDrop = 2;
    }
    #endregion

    #region -- Flying Eye --
    public void FlyingEye()
    {
        maxHP = 180;
        hp = 180;
        def = 35;
        atk = 50;
        atkRange = 1;
        atkDelay = 2f;
        speed = 0.25f;
        costDrop = 2;
    }
    #endregion

    #region -- Golem --
    public void Golem()
    {
        maxHP = 500;
        hp = 500;
        def = 150;
        atk = 130;
        atkRange = 1;
        atkDelay = 4.5f;
        speed = 0.2f;
        costDrop = 3;
    }
    #endregion

    #region -- Fire Worm --
    public void FireWorm()
    {
        maxHP = 350;
        hp = 350;
        def = 100;
        atk = 125;
        atkRange = 1;
        atkDelay = 2f;
        speed = 0.35f;
        costDrop = 3;
    }
    #endregion

    #region -- Trash monster --
    public void TrashMonster()
    {
        maxHP = 180;
        hp = 180;
        def = 55;
        atk = 25;
        atkRange = 1;
        atkDelay = 2.5f;
        speed = 0.15f;
        costDrop = 2;
    }
    #endregion

    #region -- Tooth walker --
    public void ToothWaler()
    {
        maxHP = 120;
        hp = 120;
        def = 18;
        atk = 25;
        atkRange = 1;
        atkDelay = 0.6f;
        speed = 0.4f;
        costDrop = 1;
    }
    #endregion

    #endregion
}
