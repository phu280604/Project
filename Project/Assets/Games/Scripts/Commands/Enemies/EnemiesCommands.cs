using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCommands : MonoBehaviour
{
    #region --- Method ---

    public List<GameObject> Enemies { get { return enemies; }  set { enemies = value; } }

    #endregion

    #region --- Field ---

    [SerializeField] private static List<GameObject> enemies = new List<GameObject>();

    #endregion
}
