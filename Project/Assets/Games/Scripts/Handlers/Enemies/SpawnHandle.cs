using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SpawnHandle : MonoBehaviour
{
    #region --- Method ---

    #region -- Spawn minion --
    private void SpawnMiniVan()
    {
        foreach (var item in minion)
        {
            int nums = Random.Range(3, 6);
            quanlity[item] = nums;
        }
    }
    #endregion

    #region -- Duplicate enemy --
    private void DuplicateEnemy()
    {
        foreach (var item in quanlity)
        {
            for (int i = 0; i < item.Value; i++)
            {
                GameObject enemiesDup = Instantiate(item.Key);
                enemiesDup.name = enemiesDup.name + " #" + (i + 1);
                commands.Enemies.Add(enemiesDup);
            }
        }
    }
    #endregion

    private void Start()
    {
        quanlity = new Dictionary<GameObject, int>();
        maxEnemies = 0;
        curEnemies = 0;
        delaySpawn = 5f;
        spawn = 0;

        SpawnMiniVan();

        foreach (var item in quanlity)
        {
            maxEnemies += item.Value;
        }

        DuplicateEnemy();
    }

    #region -- Spawn --
    private void Spawn()
    {
        int nums = Random.Range(2, 4);

        if (curEnemies + nums < maxEnemies && curEnemies < maxEnemies)
        {
            while (nums > 0)
            {
                int category = Random.Range(0, commands.Enemies.Count);
                if (!commands.Enemies[category].activeSelf)
                {
                    commands.Enemies[category].SetActive(true);
                    nums--;
                    curEnemies++;
                }
            }
        }
        else if (curEnemies + nums > maxEnemies && curEnemies < maxEnemies)
        {
            foreach(var item in commands.Enemies)
            {
                if (!item.activeSelf)
                {
                    item.SetActive(true);
                    curEnemies++;
                }
            }
        }

        spawn += Time.deltaTime;
    }
    #endregion

    #region -- Spawn delay --
    private void DelaySpawn()
    {
        if (spawn <= delaySpawn)
            spawn += Time.deltaTime;
        else spawn = 0;
    }
    #endregion

    private void FixedUpdate()
    {
        if (managerCommands.StartTime)
        {
            if (spawn == 0 && curEnemies <= maxEnemies)
                Spawn();
            else if (spawn != 0 && curEnemies <= maxEnemies)
                DelaySpawn();
        }
    }
    #endregion

    #region --- Field ---

    [SerializeField] private GameManagerCommands managerCommands;
    [SerializeField] private EnemiesCommands commands;
    [SerializeField] private int maxEnemies;
    [SerializeField] private List<GameObject> minion;
    [SerializeField] private Dictionary<GameObject, int> quanlity;
    private int curEnemies;
    private float delaySpawn;
    private float spawn;

    #endregion
}
