using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHP : MonoBehaviour
{
    #region --- Method ---

    private void Awake()
    {
        hpValue.text = gameCommands.HP.ToString();
    }

    private void Update()
    {
        if (gameCommands.HP <= 0)
            hpValue.text = "0";
        else
            hpValue.text = gameCommands.HP.ToString();
    }

    #endregion

    #region --- Field ---

    [SerializeField] private GameManagerCommands gameCommands;
    [SerializeField] private TextMeshProUGUI hpValue;

    #endregion
}
