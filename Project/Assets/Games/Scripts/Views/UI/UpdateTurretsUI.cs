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

        SetTextCost();
        SetTextName();
    }

    private void SetTextCost()
    {
        if (spawnOnClick.TurretPrefab == null || !spawnOnClick.TurretPrefab.activeSelf)
        {
            if (stats.Cost < 10 && 0 <= stats.Cost)
                costValue.text = "0" + stats.Cost.ToString();
            else
                costValue.text = stats.Cost.ToString();

            return;
        }

        if (spawnOnClick.TurretPrefab.activeSelf && spawnOnClick.TurretPrefab != null)
        {
            if (stats.Cost < 10 && 0 <= stats.Cost)
                costValue.text = "0" + stats.CostUpgrade.ToString();
            else
                costValue.text = stats.CostUpgrade.ToString();
            return;
        }
    }

    private void SetTextName()
    {
        if (spawnOnClick.TurretPrefab == null || !spawnOnClick.TurretPrefab.activeSelf)
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

    #region --- Field ---

    [Header("Turrets coponent")]
    private StatsTurrets stats;
    [SerializeField] private SpawnOnClick spawnOnClick;

    [Header("Text values")]
    [SerializeField] private TextMeshProUGUI costValue;
    [SerializeField] private TextMeshProUGUI nameValue;

    private GameObject turrets;
    
    #endregion
}
