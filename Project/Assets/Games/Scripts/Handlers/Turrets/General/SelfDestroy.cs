using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    #region --- Method ---

    void Start()
    {
        Invoke("SelfDes", stats.AtkDelay);
    }

    #region -- Self destroy --
    public void SelfDes()
    {
        Destroy(gameObject);
    }
    #endregion

    #endregion

    #region --- Field ---

    [SerializeField] private StatsTurrets stats;

    #endregion
}
