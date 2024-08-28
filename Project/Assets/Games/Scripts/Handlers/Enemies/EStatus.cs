using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EStatus : MonoBehaviour
{
    #region --- Method ---
    private void Start()
    {
        isAttacking = false;
        isMoving = true;
        isDying = false;
    }

    public bool IsAttacking { get { return isAttacking; } set { isAttacking = value; } }
    public bool IsMoving { get { return isMoving; } set { isMoving = value; } }
    public bool IsDying { get { return isDying; } set { isDying = value; } }

    #endregion

    #region --- Field ---

    [SerializeField] private bool isAttacking;
    [SerializeField] private bool isMoving;
    [SerializeField] private bool isDying;

    #endregion
}
