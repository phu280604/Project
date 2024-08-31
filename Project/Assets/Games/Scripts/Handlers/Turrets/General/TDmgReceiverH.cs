using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDmgReceiverH : MonoBehaviour
{
    #region --- Method ---

    #region -- Receive Dmg --
    public void Receive(float dmg)
    {
        float dmgDeal = (dmg - stats.Def);
        if (dmgDeal <= 0)
            stats.Hp -= 1;
        else if (dmgDeal > 0)
            stats.Hp -= dmgDeal;

        healthBar.UpdateHelthBar(stats.Hp, stats.MaxHP);

        if (stats.Hp <= 0)
        {
            Dead();
        }
    }
    #endregion

    #region -- Dead --
    private void Dead()
    {
        status.IsDying = true;
        Destroy(objParent);
    }
    #endregion

    #endregion

    #region --- Field --- 

    [SerializeField] private THealthBarCtrl healthBar;
    [SerializeField] private StatsTurrets stats;
    [SerializeField] private StatusH status;
    [SerializeField] private GameObject objParent;

    #endregion
}
