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
        pause = false;

        wave = 1;
        hp = 1000;
        speed = 2;
    }

    private void FixedUpdate()
    {
        if (!start)
            skipBtn.SetActive(true);
        else 
            skipBtn.SetActive(false);
    }


    #region -- Get - Set Method --
    public bool StartTime { get { return start; } set { start = value; } }
    public float HP { get { return hp; } set { hp = value; } }
    public int Wave { get { return wave; } set { wave = value; } }
    public bool PauseTime { get { return pause; } set { pause = value; } }
    #endregion

    #endregion

    #region --- Field ---

    [SerializeField] private GameObject skipBtn;

    private bool start;
    private bool pause;

    [SerializeField] private static int wave;
    [SerializeField] private static float hp;
    [SerializeField] private static float speed;

    #endregion
}
