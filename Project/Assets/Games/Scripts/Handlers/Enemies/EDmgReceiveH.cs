using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDmgRecerverH : MonoBehaviour
{
    #region --- Method ---

    public void EDmgRecerver(float dmg)
    {
        float dmgDeal = (dmg - stats.Def);
        if (dmgDeal < 0)
            stats.Hp -= 1;
        else if (dmgDeal > 0)
            stats.Hp -= dmgDeal;
    }

    private void Dead()
    {
        commands.Enemies.Remove(gameObject);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (stats.Hp <= 0) Dead();
    }

    #endregion

    #region --- Field ---

    [SerializeField] private StatsEnemies stats;
    [SerializeField] private EnemiesCommands commands;

    #endregion
}
