using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMKI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        upgradeBtn.onClick.AddListener(Upgrade);
    }

    private void Upgrade()
    {
        if (gameCommands.BuildingTime)
        {
            if (spawnOnClick.TurretPrefab != null)
            {
                objUpgrade = spawnOnClick.TurretPrefab;
                status = objUpgrade.GetComponent<StatusH>();

                if (objUpgrade.activeSelf && !status.IsUpgrade)
                {
                    status.IsUpgrade = true;
                }
            }
        }
    }

    #region --- Field ---

    [SerializeField] private GameManagerCommands gameCommands;
    [SerializeField] private StatusH status;
    [SerializeField] private SpawnOnClick spawnOnClick;
    [SerializeField] private GameObject objUpgrade;

    [SerializeField] private Button upgradeBtn;

    #endregion
}
