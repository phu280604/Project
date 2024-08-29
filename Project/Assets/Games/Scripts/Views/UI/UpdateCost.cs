using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateCost : MonoBehaviour
{
    #region --- Method ---

    private void Awake()
    {
        costValue.text = gameCommands.Cost.ToString();
    }

    private void Update()
    {
        costValue.text = gameCommands.Cost.ToString();
    }

    #endregion

    #region --- Field ---

    [SerializeField] private GameManagerCommands gameCommands;
    [SerializeField] private TextMeshProUGUI costValue;

    #endregion
}
