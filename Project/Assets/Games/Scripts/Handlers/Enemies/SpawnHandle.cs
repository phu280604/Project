using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnHandle : MonoBehaviour
{
    #region --- Method ---

    #region -- Spawn minion --
    private void SpawnMinion()
    {
        List<GameObject> minionNums = new List<GameObject>();
        while (minionNums.Count < 3)
        {
            int rnd = Random.Range(0, minion.Count);
            if (!minionNums.Contains(minion[rnd]))
            {
                minionNums.Add(minion[rnd]);
            }
        }

        foreach (var item in minionNums)
        {
            int nums = Random.Range(1 + gameCommands.Wave, 3 + gameCommands.Wave);
            if (!quanlity.ContainsKey(item))
            {
                quanlity[item] = nums;
                maxEnemies += nums;
            }
        }
    }
    #endregion

    #region -- Spawn elite --
    private void SpawnElite()
    {
        List<GameObject> eliteNums = new List<GameObject>();
        while (eliteNums.Count < 2)
        {
            int rnd = Random.Range(0, elite.Count);
            if (!eliteNums.Contains(elite[rnd]))
            {
                eliteNums.Add(elite[rnd]);
            }
        }

        foreach (var item in eliteNums)
        {
            int nums = Random.Range(2 + gameCommands.Wave, 3 + (gameCommands.Wave / 2));
            if (!quanlity.ContainsKey(item))
            {
                quanlity[item] = nums;
                maxEnemies += nums;
            }
        }
    }
    #endregion

    #region -- Spawn boss --
    private void SpawnBoss()
    {
        List<GameObject> bossNums = new List<GameObject>();
        while (bossNums.Count < 1)
        {
            int rnd = Random.Range(0, boss.Count);
            if (!bossNums.Contains(boss[rnd]))
            {
                bossNums.Add(boss[rnd]);
            }
        }

        if (!quanlity.ContainsKey(bossNums[0]))
        {
            quanlity[bossNums[0]] = 1;
            maxEnemies += 1;
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
                commands.Enemies[enemiesDup] = true;
            }
        }
    }
    #endregion

    #region -- Spawn --
    private void Spawn()
    {
        List<KeyValuePair<GameObject, bool>> enemiesList = commands.Enemies.ToList();
        enemiesList[curEnemies].Key.SetActive(true);
        curEnemies ++;

        spawn += Time.deltaTime;
    }
    #endregion

    #region -- Spawn delay --
    private void DelaySpawn()
    {
        if (spawn <= delaySpawn)
            spawn += Time.deltaTime;
        else
        {
            delaySpawn = Random.Range(1f, 4f);
            spawn = 0;
        }
    }
    #endregion

    private void Update()
    {
        if (gameCommands.Wave < 6)
        {
            if (!gameCommands.PauseTime && !ui.activeSelf)
            {
                if (!spawned)
                {
                    DuplicateEnemy();

                    List<KeyValuePair<GameObject, bool>> enemiesList = commands.Enemies.ToList();

                    System.Random rnd = new System.Random();
                    enemiesList = enemiesList.OrderBy(item => rnd.Next()).ToList();

                    spawned = true;

                    commands.NextWave = true;
                }

                if (spawn == 0 && curEnemies < maxEnemies)
                    Spawn();
                else if (spawn != 0 && curEnemies < maxEnemies)
                {
                    DelaySpawn();
                }
            }
        }
    }

    private void OnEnable()
    {
        quanlity = new Dictionary<GameObject, int>();
        commands.Enemies = new Dictionary<GameObject, bool>();

        commands.NextWave = false;
        commands.EnemiesCount = 0;
        maxEnemies = 0;
        curEnemies = 0;
        curDup = 0;
        delaySpawn = 2f;
        spawn = 0;
        curWave = 0;

        spawned = false;

        SpawnByWave();
    }

    #region -- Spawn by wave --
    private void SpawnByWave()
    {
        if (gameCommands.Wave == 5)
        {
            SpawnBoss();
            return;
        }

        if (gameCommands.Wave <= 2)
        {
            SpawnMinion();
            return;
        }
        else if (2 < gameCommands.Wave && gameCommands.Wave <= 4)
        {
            SpawnMinion();
            SpawnElite();
            return;
        }
    }
    #endregion

    public int MaxEnemies { get { return maxEnemies; } }

    #endregion

    #region --- Field ---

    [Header("Enemies component")]
    [SerializeField] private GameManagerCommands gameCommands;
    [SerializeField] private EnemiesCommands commands;
    [SerializeField] private List<GameObject> minion;
    [SerializeField] private List<GameObject> elite;
    [SerializeField] private List<GameObject> boss;
    private Dictionary<GameObject, int> quanlity;

    [Header("Wave")]
    [SerializeField] private int curWave;
    [SerializeField] private GameObject ui;

    [Header("Duplicate enemies")]
    [SerializeField] private int curDup;

    [Header("Enemies")]
    [SerializeField] private int maxEnemies;
    [SerializeField] private int curEnemies;


    private float delaySpawn;
    private float spawn;
    private bool spawned;

    #endregion
}
