using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTime : MonoBehaviour
{
    #region --- Method ---

    void Start()
    {
        skipBtn.onClick.AddListener(Skip);
    }

    private void Skip()
    {
        commands.StartTime = true;
    }

    #endregion

    #region --- Field ---

    [SerializeField] private GameManagerCommands commands;
    [SerializeField] private Button skipBtn;

    #endregion
}
