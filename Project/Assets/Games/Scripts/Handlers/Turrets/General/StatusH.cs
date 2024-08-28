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
        isAttacking = true;
        isDying = false;
    }

    public bool IsPlacing { get { return isPlacing; } set { isPlacing = value; } }
    public bool IsDying { get { return isDying; } set { isDying = value; } }
    public bool IsAttacking { get { return isAttacking; } set { isAttacking = value; } }


    #endregion

    #region --- Field ---

    [SerializeField] private bool isPlacing;
    [SerializeField] private bool isDying;
    [SerializeField] private bool isAttacking;

    #endregion
}
