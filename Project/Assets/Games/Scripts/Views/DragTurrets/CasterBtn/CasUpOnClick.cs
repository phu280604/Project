using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class CasUpOnClick : MonoBehaviour
{

    private void Start()
    {
        button.onClick.AddListener(Upgrade);
    }

    private void FixedUpdate()
    {
        if (this.gameObject != null)
        {
            button = this.gameObject.GetComponent<Button>();
            spawnOnClick = this.gameObject.GetComponent<SpawnOnClick>();
            if (this.spawnOnClick.TurretPrefab != null)
                status = this.spawnOnClick.TurretPrefab.GetComponent<StatusH>();
        }
    }

    private void Upgrade()
    {
        if (this.spawnOnClick.TurretPrefab != null && this.spawnOnClick.TurretPrefab.activeSelf)
        {
            GameManagerCommands gameCommands = GameObject.FindWithTag("GameController").GetComponent<GameManagerCommands>();

            if (status.IsPlacing && !status.IsUpgrade && gameCommands.BuildingTime)
            {
                StatsTurrets stats = spawnOnClick.TurretPrefab.GetComponent<StatsTurrets>();
                
                if (gameCommands.Cost - stats.CostUpgrade >= 0)
                {
                    CasterUpgrade casterUp = spawnOnClick.GetComponent<CasterUpgrade>();

                    status.IsUpgrade = true;
                    gameCommands.Cost -= stats.CostUpgrade;
                }
            }
        }
    }

    [SerializeField] private Button button;
    private SpawnOnClick spawnOnClick;
    private StatusH status;
}
