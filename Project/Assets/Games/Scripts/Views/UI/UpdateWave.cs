using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateWave : MonoBehaviour
{
    #region --- Method ---

    private void Awake()
    {
        waveValue.text = "Wave " + gameCommands.Wave.ToString();
    }

    private void Update()
    {
        if (gameCommands.Wave == 5)
        {
            waveValue.text = "Final Wave";
        }
        else
        {
            waveValue.text = "Wave " + gameCommands.Wave.ToString();
        }
    }

    #endregion

    #region --- Field ---

    [SerializeField] private GameManagerCommands gameCommands;
    [SerializeField] private TextMeshProUGUI waveValue;

    #endregion
}
