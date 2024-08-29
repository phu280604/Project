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

        wave = 1;
        hp = 1000;
        cost = 30;
    }

    private void Update()
    {
        if (hp <= 0)
        {
            Time.timeScale = 0f;
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

    [SerializeField] private static int wave;
    [SerializeField] private static float hp;
    [SerializeField] private static int cost;

    #endregion
}
