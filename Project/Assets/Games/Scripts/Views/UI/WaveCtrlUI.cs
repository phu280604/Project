using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveCtrlUI : MonoBehaviour
{
    #region --- Method ---

    private void Update()
    {
        if (gameCommands.BuildingTime)
        {
            textValue.text = "Building Time ...";
            ui.SetActive(true);
        }

        if (gameCommands.PauseTime && !gameCommands.BuildingTime)
        {
            settingUI.SetActive(true);
        }

        if (gameCommands.StartTime && enemiesCommands.Enemies.Count <= 0)
        {
            textValue.text = "Wave " + gameCommands.Wave + " Start!";
            Invoke("SetActive", 1f);
        }
        else if (gameCommands.StartTime && enemiesCommands.Enemies.Count > 0)
        {
            textValue.text = "Wave " + gameCommands.Wave + " Continue!";
            Invoke("SetActive", 1f);
        }
    }

    private void SetActive()
    {
        ui.SetActive(false);
    }

    #endregion

    #region --- Field ---

    [SerializeField] private GameManagerCommands gameCommands;
    [SerializeField] private EnemiesCommands enemiesCommands;
    [SerializeField] private TextMeshProUGUI textValue;
    [SerializeField] private GameObject ui;
    [SerializeField] private GameObject settingUI;

    #endregion
}
