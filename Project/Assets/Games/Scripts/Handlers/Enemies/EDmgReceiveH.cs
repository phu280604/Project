using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDmgReceiverH : MonoBehaviour
{
    #region --- Method ---

    #region -- Enemies dmg receive --
    public void EDmgRecerver(float dmg)
    {
        float dmgDeal = (dmg - stats.Def);
        if (dmgDeal <= 0)
            stats.Hp -= 1;
        else if (dmgDeal > 0)
            stats.Hp -= dmgDeal;
    }
    #endregion

    #region -- Dead --
    private void Dead()
    {
        commands.Enemies.Remove(objParent);
        Destroy(objParent);
    }
    #endregion

    private void Update()
    {
        if (stats.Hp <= 0) Dead();
    }

    #endregion

    #region --- Field ---

    [SerializeField] private StatsEnemies stats;
    [SerializeField] private EnemiesCommands commands;

    [SerializeField] private GameObject objParent;

    #endregion
}
