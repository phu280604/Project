using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDmgSenderH : MonoBehaviour
{
    #region --- Method ---

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EDmgRecerverH eDmgReceiver = collision.GetComponent<EDmgRecerverH>();
        eDmgReceiver.EDmgRecerver(stats.Atk);
    }

    #endregion

    #region --- Field ---

    [SerializeField] private StatsTurrets stats;

    #endregion
}
