using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SingleDmgSenderH : MonoBehaviour
{
    #region --- Method ---

    public void Update()
    {
       if (!gameCommands.PauseTime)
        {
            if (shoot.GetDistance <= 0.2 && shoot.Target != null)
            {
                EDmgReceiverH eDmgRecerverH = shoot.Target.GetComponentInChildren<EDmgReceiverH>();
                if (eDmgRecerverH != null)
                {
                    eDmgRecerverH.EDmgRecerver(stats.Atk);
                    Destroy(gameObject);
                }
                else
                    Debug.Log("Can't find component 'EDmgReceiverH'");
            }
        }
    }

    #endregion

    #region --- Field ---

    [SerializeField] private GameManagerCommands gameCommands;
    [SerializeField] private ShootH shoot;
    [SerializeField] private StatsTurrets stats;

    #endregion
}
