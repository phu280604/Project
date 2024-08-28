using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDmgReceiverH : MonoBehaviour
{
    #region --- Method ---

    public void Receive(float dmg)
    {
        float dmgDeal = (dmg - stats.Def);
        if (dmgDeal <= 0)
            stats.Hp -= 1;
        else if (dmgDeal > 0)
            stats.Hp -= dmgDeal;
                

        if (stats.Hp <= 0)
        {
           status.IsDying = true;
           Destroy(objParent);
        }
    }

    #endregion

    #region --- Field --- 

    [SerializeField] private StatsTurrets stats;
    [SerializeField] private StatusH status;
    [SerializeField] private GameObject objParent;

    #endregion
}
