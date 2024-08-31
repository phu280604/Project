using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTurretsUI : MonoBehaviour
{
    #region --- Method ---

    void Update()
    {
        if (spawnOnClick.TurretPrefab == null)
        {
            turrets = spawnOnClick.Turret;
        }
        else
        {
            turrets = spawnOnClick.TurretPrefab;
        }
        stats = turrets.GetComponent<StatsTurrets>();
        status = turrets.GetComponent<StatusH>();

        SetTextCost();
        SetTextName();
        SetIconUpgrade();
    }

    #region -- Set cost --
    private void SetTextCost()
    {
        if (!status.IsPlacing)
        {
            if (stats.Cost < 10 && 0 <= stats.Cost)
                costValue.text = "0" + stats.Cost.ToString();
            else
                costValue.text = stats.Cost.ToString();

            return;
        }

        if (status.IsPlacing)
        {
            if (stats.Cost < 10 && 0 <= stats.Cost)
                costValue.text = "0" + stats.CostUpgrade.ToString();
            else
                costValue.text = stats.CostUpgrade.ToString();
            return;
        }
    }
    #endregion

    #region -- Set name --
    private void SetTextName()
    {
        if (!status.IsPlacing)
        {
            nameValue.text = spawnOnClick.Turret.name;
        }
        else
        {
            if (stats.Lvl == 5)
            {
                nameValue.text = spawnOnClick.TurretPrefab.name + " Max";
            }
            else
            {
                nameValue.text = spawnOnClick.TurretPrefab.name + " lvl " + stats.Lvl;
            }
        }
    }
    #endregion

    #region -- Set icon upgrade --
    private void SetIconUpgrade()
    {
        if (spawnOnClick.TurretPrefab != null)
        {
            StatusH statusChecker = spawnOnClick.TurretPrefab.GetComponent<StatusH>();
            StatsTurrets statsChecker = spawnOnClick.TurretPrefab.GetComponent<StatsTurrets>();
            if (statusChecker.IsPlacing)
            {
                if (statsChecker.Lvl < 5)
                {
                    iconUpgrade.SetActive(true);
                }
                else
                {
                    iconUpgrade.SetActive(false);
                }
            }
            else
            {
                iconUpgrade.SetActive(false);
            }
        }
        else
        {
            iconUpgrade.SetActive(false);
        }
    }
    #endregion

    #endregion

    #region --- Field ---

    [Header("Turrets coponent")]
    private StatsTurrets stats;
    private StatusH status;
    [SerializeField] private ButtonOnClickEvent spawnOnClick;

    [Header("Text values")]
    [SerializeField] private TextMeshProUGUI costValue;
    [SerializeField] private TextMeshProUGUI nameValue;
    [SerializeField] private GameObject iconUpgrade;
    private GameObject turrets;
    
    #endregion
}
