using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StatusH : MonoBehaviour
{
    #region --- Method ---

    private void Start()
    {
        isPlacing = false;
        isUpgrade = false;
        isAttacking = false;
        isDying = false;
    }

    public bool IsPlacing { get { return isPlacing; } set { isPlacing = value; } }
    public bool IsUpgrade { get { return isUpgrade; } set { isUpgrade = value; } }
    public bool IsDying { get { return isDying; } set { isDying = value; } }
    public bool IsAttacking { get { return isAttacking; } set { isAttacking = value; } }


    #endregion

    #region --- Field ---

    [SerializeField] private bool isPlacing;
    [SerializeField] private bool isUpgrade;
    [SerializeField] private bool isAttacking;
    [SerializeField] private bool isDying;
  
    #endregion
}
