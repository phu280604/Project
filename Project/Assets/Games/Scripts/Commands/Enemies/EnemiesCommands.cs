using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemiesCommands : MonoBehaviour
{
    #region --- Method ---

    private void Update()
    {
        if (enemies.Count == enemiesCount && nextWave)
        {
            pauStaH.NextWave();
            nextWave = false;
        }
    }

    #region -- Get/Set method --
    public Dictionary<GameObject, bool> Enemies { get { return enemies; } set { enemies = value; } }
    public int EnemiesCount { get { return enemiesCount; } set { enemiesCount = value; } }
    public bool NextWave { get { return nextWave; } set { nextWave = value; } }
    #endregion

    #endregion

    #region --- Field ---

    [SerializeField] private static Dictionary<GameObject, bool> enemies;
    [SerializeField] private int enemiesCount;
    [SerializeField] private GameManagerCommands commands;
    [SerializeField] private PauseStartH pauStaH;
    [SerializeField] private bool nextWave;

    #endregion
}
