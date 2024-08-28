using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCommands : MonoBehaviour
{
    #region --- Method ---

    private void Start()
    {
        enemies = new Dictionary<GameObject, bool>();
        enemiesCount = 1;
    }

    private void FixedUpdate()
    {
        if (enemiesCount == enemies.Count)
        {
            enemies.Clear();
            commands.StartTime = false;
            commands.Wave += 1;
        }
    }

    public Dictionary<GameObject, bool> Enemies { get { return enemies; } set { enemies = value; } }
    public int EnemiesCount { get { return enemiesCount; } set { enemiesCount = value; } }

    #endregion

    #region --- Field ---

    [SerializeField] private static Dictionary<GameObject, bool> enemies;
    [SerializeField] private static int enemiesCount;
    [SerializeField] private GameManagerCommands commands;

    #endregion
}
