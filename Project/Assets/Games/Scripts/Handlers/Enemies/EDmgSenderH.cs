using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EDmgSenderH : MonoBehaviour
{
    #region --- Method ---

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision != null && (collision.tag == "Turrets" || collision.tag == "EndPoint"))
        {
            block = collision.gameObject;
            status.IsAttacking = true;
            status.IsMoving = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "EndPoint")
        {
            block = null;
            status.IsAttacking = false;
            status.IsMoving = false;
        }
        else if (collision != null && (collision.tag == "Turrets" || collision.tag == "EndPoint"))
        {
            block = null;
            status.IsAttacking = false;
            status.IsMoving = true;
        }
    }

    public GameObject Block { get { return block; } set { block = value; } }

    #endregion

    #region --- Field ---

    [SerializeField] private EStatus status;
    [SerializeField] private StatsEnemies stats;
    [SerializeField] private GameObject block;

    #endregion
}
