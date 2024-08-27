using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCommands : MonoBehaviour
{
    #region --- Method ---

    public List<GameObject> Bullets { get { return bullets; } set { bullets = value; } }

    #endregion

    #region --- Field ---

    [SerializeField] private List<GameObject> bullets = new List<GameObject>();

    #endregion
}
