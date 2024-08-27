using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeDmgSenderH : MonoBehaviour
{
    #region --- Method ---

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EDmgReceiverH eDmgReceiver = collision.GetComponent<EDmgReceiverH>();
        if (eDmgReceiver != null)
        {
            eDmgReceiver.EDmgRecerver(stats.Atk);
            Destroy(gameObject);
        }
        else
            Debug.Log("Can't find component 'EDmgReceiverH'");
    }

    #endregion

    #region --- Field ---

    [SerializeField] private StatsTurrets stats;

    #endregion
}
