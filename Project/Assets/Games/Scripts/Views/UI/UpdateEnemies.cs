using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateEnemies : MonoBehaviour
{
    #region --- Method ---

    private void Awake()
    {
        string count = enemiesCommands.EnemiesCount.ToString();
        string max = enemiesSpawn.MaxEnemies.ToString();
        if (enemiesSpawn.MaxEnemies < 10 && 0 <= enemiesSpawn.MaxEnemies)
        {
            max = "0" + enemiesSpawn.MaxEnemies;
        }

        if (enemiesCommands.EnemiesCount < 10 && 0 <= enemiesCommands.EnemiesCount)
        {
            count = "0" + enemiesCommands.EnemiesCount;
        }

        enemiesValues.text = count + "/" + max;
    }

    private void Update()
    {
        string count = enemiesCommands.EnemiesCount.ToString();
        string max = enemiesSpawn.MaxEnemies.ToString();
        if (enemiesSpawn.MaxEnemies < 10 && 0 <= enemiesSpawn.MaxEnemies)
        {
            max = "0" + enemiesSpawn.MaxEnemies;
        }

        if (enemiesCommands.EnemiesCount < 10 && 0 <= enemiesCommands.EnemiesCount)
        {
            count = "0" + enemiesCommands.EnemiesCount;
        }

        enemiesValues.text = count + "/" + max;
    }

    #endregion

    #region --- Field ---

    [SerializeField] private EnemiesCommands enemiesCommands;
    [SerializeField] private SpawnHandle enemiesSpawn;
    [SerializeField] private TextMeshProUGUI enemiesValues;

    #endregion
}
