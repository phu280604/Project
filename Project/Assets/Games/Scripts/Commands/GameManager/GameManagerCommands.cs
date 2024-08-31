using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerCommands : MonoBehaviour
{
    #region --- Method ---

    private void Start()
    {
        start = false;
        pause = true;
        building = true;

        checker = false;

        wave = 1;
        hp = 1000;
        cost = 30;
    }

    private void Update()
    {
        if (hp <= 0 && !checker)
        {
            pause = true;
            start = false;
            building = false;

            List<GameObject> listEnemies = new List<GameObject>(enemies.Enemies.Keys);
            foreach(var enemy in listEnemies)
            {
                enemies.Enemies.Remove(enemy);
                Destroy(enemy);
            }

            GameObject[] turretsDeloy = GameObject.FindGameObjectsWithTag("TurretClone");
            List<GameObject> turrets = new List<GameObject>(turretsDeloy);
            foreach (var turret in turrets)
            {
                Destroy(turret);
            }

            map.SetActive(false);

            mainUI.SetActive(false);
            uiDefeat.SetActive(true);
            uiVictory.SetActive(false);

            checker = true;
        }

        if (wave >= 6 && checker)
        {
            pause = false;
            start = false;
            building = false;

            List<GameObject> listEnemies = new List<GameObject>(enemies.Enemies.Keys);
            foreach (var enemy in listEnemies)
            {
                enemies.Enemies.Remove(enemy);
                Destroy(enemy);
            }

            GameObject[] turretsDeloy = GameObject.FindGameObjectsWithTag("TurretClone");
            List<GameObject> turrets = new List<GameObject>(turretsDeloy);
            foreach (var turret in turrets)
            {
                Destroy(turret);
            }

            map.SetActive(false);

            bossHealthBar.SetActive(false);

            mainUI.SetActive(false);
            uiDefeat.SetActive(false);
            uiVictory.SetActive(true);

            checker = false;
        }

        if (wave == 5 && start && !checker && enemies.Enemies.Count == 1)
        {
            bossHealthBar.SetActive(true);

            checker = true;
        }
    }


    #region -- Get - Set Method --
    public bool StartTime { get { return start; } set { start = value; } }
    public float HP { get { return hp; } set { hp = value; } }
    public int Cost { get { return cost; } set { cost = value; } }
    public int Wave { get { return wave; } set { wave = value; } }
    public bool PauseTime { get { return pause; } set { pause = value; } }
    public bool BuildingTime { get { return building; } set { building = value; } }
    #endregion

    #endregion

    #region --- Field ---

    private bool start;
    private bool pause;
    private bool building;

    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject uiDefeat;
    [SerializeField] private GameObject uiVictory;
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject bossHealthBar;
    [SerializeField] private EnemiesCommands enemies;

    private bool checker;

    [SerializeField] private static int wave;
    [SerializeField] private static float hp;
    [SerializeField] private static int cost;

    #endregion
}
